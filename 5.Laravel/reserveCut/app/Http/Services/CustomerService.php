<?php

// Specify the namespace for HTTP service classes to organize service-related classes
namespace App\Http\Services;

// Import the Customer model to interact with Customer's data in the database
use App\Models\Customer;
// Import the Request class to handle HTTP requests in service methods
use Illuminate\Http\Request;
// Import the Validator facade to validate incoming data against specific rules
use Illuminate\Support\Facades\Validator;
// Import the ModelNotFoundException for handling cases where a model instance isn't found in the database
use Illuminate\Database\Eloquent\ModelNotFoundException;
// Imports the CustomerResource class, which provides a means to format and return Customer data structures for API responses
use App\Http\Resources\CustomerResource;
// Imports the ApiResponse helper class to standardize and simplify the creation of JSON responses throughout the application
use App\Http\Middleware\ApiResponse;
// Use the Storage facade to interact with the filesystem
use Illuminate\Support\Facades\Storage;

/**
 * Define the service class for handling Customer operations
 */
class CustomerService
{
    /**
    * Retrieves and returns all Customers along with their associated Haircut and Reservations from the database.
    * This method ensures that the returned collection of Customer models is formatted using ApiResponse::format with CustomerResource to ensure consistency and accuracy of the API response.
    *
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing a collection of Customer models, each including details about associated Haircut and Reservations. The data is formatted for API consistency and accuracy.
    * If there's an error during the fetching process, it returns a JSON response with a code 500 status.
    */
    public function indexCustomer()
    {
        try {
            // Return all Customers records from the database with its related Haircut and Reservations
            $customers = Customer::with('haircut','reservations')->get();
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including all the retrieved Customers details, formatted using ApiResponse::format
            //return ApiResponse::format('customers', CustomerResource::collection($customers), 200);
            return response()->json(CustomerResource::collection($customers), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Retrieves and returns a single Customer along with its associated Haircut and Reservations from the database by the Customer's ID.
    * This method ensures that the returned Customer is formatted using ApiResponse::format with CustomerResource to ensure consistency and accuracy of the API response.
    *
    * @param string $id The ID of the Customer to retrieve.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the specific Customer model, including details about associated Haircut and Reservations. If successful, it returns a JSON response with a code 200 status.
    * If the Customer is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the retrieval process, it returns a JSON response with a code 500 status.
    */
    public function showCustomer($id)
    {
        try {
            // Attempt to find the Customer by its ID, including Haircut and Reservations. If not found, a ModelNotFoundException is thrown
            $customer = Customer::with('haircut', 'reservations')->findOrFail($id);
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including the retrieved Customer details, formatted using ApiResponse::format
            //return ApiResponse::format('customer', new CustomerResource($customer), 200);
            return response()->json(new CustomerResource($customer), 200);
        } catch (ModelNotFoundException $e){
            // If the Customer is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Customer) does not exist
            return response()->json(['message' => 'Customer not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and stores a new Customer record based on the provided request data, including associating Haircuts if specified.
    * This method ensures data validation and handles errors or exceptions by returning appropriate JSON responses.
    * 
    * @param \Illuminate\Http\Request $request Request object containing the data for creating a Customer and associating Haircuts.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the newly created Customer model. If the creation is successful, it includes details about associated Haircuts, formatted using ApiResponse::format with CustomerResource to ensure consistency and accuracy of the API response.
    * If the validation is successful, it returns a JSON response with a code 200 status, indicating successful insertion.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * For any other errors during the saving process, it returns a JSON response with a code 500 status.
    */
    public function storeCustomer(Request $request)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'name' => 'required|max:64', // 'name' must be provided and cannot exceed 64 characters
                'firstname' => 'required|max:64', // 'firstname' must be provided and cannot exceed 64 characters
                'address' => 'nullable|max:128', // 'address' is optional but cannot exceed 128 characters if provided
                'postcode' => 'nullable|integer|min:0|max:999999', // 'postcode' is optional, must be an integer, and must be between 0 and 999999
                'city' => 'nullable|max:64', // 'city' is optional but cannot exceed 64 characters if provided
                'phone' => 'required|max:64', // 'phone' is required and cannot exceed 64 characters
                'email' => 'nullable|email|max:64', // 'email' is optional, must be a valid email format, and cannot exceed 64 characters
                'date_birth' => 'nullable|date', // 'date_birth' is optional and must be a valid date format
                'photo' => 'nullable|image|max:2048', // 'photo' is optional, must be an image file, and its size cannot exceed 2048 kilobytes
                'haircut_id' => 'nullable|exists:haircuts,id', // 'haircut_id' is optional but must exist in the 'haircuts' table under the 'id' column if provided
                'pref_contact' => 'nullable|max:64' // 'pref_contact' is optional but cannot exceed 64 characters if provided
            ]);
            // Check if validation fails
            if ($validator->fails()) {
               // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
               return response()->json(['errors' => $validator->errors()], 422);
            }
            // Create a new Customer instance and fill it with request data
            $customer = new Customer();
            $customer->name = $request->input('name');
            $customer->firstname = $request->input('firstname');
            $customer->address = $request->input('address');
            $customer->postcode = $request->input('postcode');
            $customer->city = $request->input('city');
            $customer->phone = $request->input('phone');
            $customer->email = $request->input('email');
            $customer->date_birth = $request->input('date_birth');
            $customer->haircut_id = $request->input('haircut_id');
            $customer->pref_contact = $request->input('pref_contact');
            // Check if the request includes a 'photo' file
            if ($request->hasFile('photo')) {
                // If a photo is included, store it in the 'customer_photos' directory within the public disk and set the Customer's photo attribute to the path of the stored file
                $photoPath = $request->file('photo')->store('customer_photos', 'public');
                $customer->photo_path = $photoPath;
            }
            // Save the Customer to the database
            $customer->save();
            // Return a JSON response with a code 200 status, indicating a successful insertion, and including the inserted Customer details, formatted using ApiResponse::format
            //return ApiResponse::format('customer', new CustomerResource($customer), 200);
            return response()->json(new CustomerResource($customer), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and updates an existing Customer record by ID based on the provided request data, including associated Haircut if specified.
    *
    * @param \Illuminate\Http\Request $request Request object containing the data for updating a Customer.
    * @param string $id The ID of the Customer to update.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the updated Customer model including details about associated Haircut, formatted using ApiResponse::format with StylistResource to ensure consistency and accuracy of the API response.
    * If successful, it returns a JSON response with a code 200 status, indicating a successful update and including the formatted details of the updated Customer.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * If the Customer is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the updating process, it returns a JSON response with a code 500 status.
    */
    public function updateCustomer(Request $request, $id)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'name' => 'required|max:64', // 'name' must be provided and cannot exceed 64 characters
                'firstname' => 'required|max:64', // 'firstname' must be provided and cannot exceed 64 characters
                'address' => 'nullable|max:128', // 'address' is optional but cannot exceed 128 characters if provided
                'postcode' => 'nullable|integer|min:0|max:999999', // 'postcode' is optional, must be an integer, and must be between 0 and 999999
                'city' => 'nullable|max:64', // 'city' is optional but cannot exceed 64 characters if provided
                'phone' => 'required|max:64', // 'phone' is required and cannot exceed 64 characters
                'email' => 'nullable|email|max:64', // 'email' is optional, must be a valid email format, and cannot exceed 64 characters
                'date_birth' => 'nullable|date', // 'date_birth' is optional and must be a valid date format
                'photo' => 'nullable|image|max:2048', // 'photo' is optional, must be an image file, and its size cannot exceed 2048 kilobytes
                'haircut_id' => 'nullable|exists:haircuts,id', // 'haircut_id' is optional but must exist in the 'haircuts' table under the 'id' column if provided
                'pref_contact' => 'nullable|in:phone,email,mail,no_contact' // 'pref_contact' is optional but cannot exceed 64 characters if provided'
                
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Attempt to find the Customer by its ID. If not found, a ModelNotFoundException is thrown
            $customer = Customer::findOrFail($id);
            // Update the Customer with request data
            $customer->name = $request->input('name');
            $customer->firstname = $request->input('firstname');
            $customer->address = $request->input('address');
            $customer->postcode = $request->input('postcode');
            $customer->city = $request->input('city');
            $customer->phone = $request->input('phone');
            $customer->email = $request->input('email');
            $customer->date_birth = $request->input('date_birth');
            $customer->haircut_id = $request->input('haircut_id');
            $customer->pref_contact = $request->input('pref_contact');
            // Check if the request includes a 'photo' file
            if ($request->hasFile('photo')) {
                // If a photo is included, store it in the 'customer_photos' directory within the public disk and set the Customer's photo attribute to the path of the stored file
                $photoPath = $request->file('photo')->store('customer_photos', 'public');
                $customer->photo_path = $photoPath;
            }
            // Save the updated Customer to the database
            $customer->save();
            // Return a JSON response with a code 200 status, indicating a successful update, and including the updated Customer details, formatted using ApiResponse::format
            //return ApiResponse::format('customer', new CustomerResource($customer), 200);
            return response()->json(new CustomerResource($customer), 200);
        } catch (ModelNotFoundException $e) {
            // If the Customer is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Customer) does not exist
            return response()->json(['message' => 'Customer not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Deletes a Customer record by ID from the database and returns a JSON response.
    * This method checks for dependencies (linked Reservations) that would prevent the deletion and handles any errors or exceptions by returning appropriate JSON responses.
    *
    * @param string $id The ID of the Customer to be deleted.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response indicating the outcome of the operation.
    * If successful, it returns a JSON response with a code 200 status, indicating successful deletion.
    * If there are linked entities preventing deletion, it returns a JSON response with a code 422 status, detailing the dependencies.
    * If the Customer is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the deletion process, it returns a JSON response with a code 500 status.
    */
    public function destroyCustomer($id)
    {
        try {
            // Attempt to find the Customer by its ID. If not found, a ModelNotFoundException is thrown
            $customer = Customer::findOrFail($id);
            // Prepare error messages if the Customer cannot be deleted
            $errorMessages = [];
            // Check for linked Reservations
            if ($customer->reservations()->exists()) {
                foreach ($customer->reservations as $reservation) {
                    $errorMessages[] = "Reservation (id:" . $reservation->id . ") from " . $reservation->date_begin . " to " . $reservation->date_end;
                }
            }
            // If there are errors related to linked Reservations preventing the deletion of the Customer, return a JSON response with a code 422 status
            if (!empty($errorMessages)) {
                return response()->json([
                    'message' => 'Cannot delete customer due to linked reservations',
                    'errors' => $errorMessages
                ], 422);
            }
            // Check if the Customer has an associated photo
            if ($customer->photo_path) {
                // Delete the photo from the storage
                Storage::delete('public/' . $customer->photo_path);
            }
            // Delete the found Customer from the database
            $customer->delete();
            // Return a JSON response with a code 200 status, indicating successful deletion
            return response()->json(['message' => 'Customer deleted successfully', 'customer_id' => $customer->id], 200);
        } catch (ModelNotFoundException $e){
            // If the Customer is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Customer) does not exist
            return response()->json(['message' => 'Customer not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

}
