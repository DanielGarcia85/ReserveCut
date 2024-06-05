<?php

// Specify the namespace for HTTP service classes to organize service-related classes
namespace App\Http\Services;

// Import the Haircut model to interact with Haircut's data in the database
use App\Models\Haircut;
// Import the Request class to handle HTTP requests in service methods
use Illuminate\Http\Request;
// Import the Validator facade to validate incoming data against specific rules
use Illuminate\Support\Facades\Validator;
// Import the ModelNotFoundException for handling cases where a model instance isn't found in the database
use Illuminate\Database\Eloquent\ModelNotFoundException;
// Imports the HaircutResource class, which provides a means to format and return Haircut data structures for API responses
use App\Http\Resources\HaircutResource;
// Imports the ApiResponse helper class to standardize and simplify the creation of JSON responses throughout the application
use App\Http\Middleware\ApiResponse;
// Use the Storage facade to interact with the filesystem
use Illuminate\Support\Facades\Storage;

/**
 * Define the service class for handling Haircut operations
 */
class HaircutService
{
    /**
    * Retrieves and returns all Haircuts from the database.
    * This method ensures that the returned collection of Haircut models is formatted using ApiResponse::format with HaircutResource to ensure consistency and accuracy of the API response.
    *
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing a collection of Haircut models, each including details about associated Haircuts.The data is formatted for API consistency and accuracy.
    * If there's an error during the fetching process, it returns a JSON response with a code 500 status.
    */
    public function indexHaircut()
    {
        try {
            // Return all Haircuts records from the database
            $haircuts = Haircut::all();
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including all the retrieved Haircuts details, formatted using ApiResponse::format
            //return ApiResponse::format('haircuts', HaircutResource::collection($haircuts), 200);
            return response()->json(HaircutResource::collection($haircuts), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Retrieves and returns a single Haircut from the database by the Haircut's ID.
    * This method ensures that the returned Haircut is formatted using ApiResponse::format with HaircutResource to ensure consistency and accuracy of the API response.
    *
    * @param string $id The ID of the Haircut to retrieve.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the specific Haircut model. If successful, it returns a JSON response with a code 200 status.
    * If the Haircut is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the retrieval process, it returns a JSON response with a code 500 status.
    */
    public function showHaircut($id)
    {
        try {
            // Attempt to find the Haircut by its ID. If not found, a ModelNotFoundException is thrown
            $haircut = Haircut::findOrFail($id);
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including the retrieved Haircut details, formatted using ApiResponse::format
            //return ApiResponse::format('haircut', new HaircutResource($haircut), 200);
            return response()->json(new HaircutResource($haircut), 200);
        } catch (ModelNotFoundException $e){
            // If the Haircut is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Haircut) does not exist
            return response()->json(['message' => 'Haircut not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and stores a new Haircut record based on the provided request data.
    * This method ensures data validation and handles errors or exceptions by returning appropriate JSON responses.
    * 
    * @param \Illuminate\Http\Request $request Request object containing the data for creating a Haircut.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the newly created Haircut model. If the creation is successful, formatted using ApiResponse::format with HaircutResource to ensure consistency and accuracy of the API response.
    * If the validation is successful, it returns a JSON response with a code 200 status, indicating successful insertion.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * For any other errors during the saving process, it returns a JSON response with a code 500 status.
    */
    public function storeHaircut(Request $request)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'name' => 'required|max:64|unique:haircuts', // 'name' is required, must not exceed 255 characters, and must be unique in the 'haircuts' table
                'description' => 'nullable|max:255', // 'description' is optional but must not exceed 255 characters if provided
                'long_short' => 'required|boolean', // 'long_short' is required and must be a boolean value (true or false)
                'cutting_time' => 'required|integer|between:15,120', // 'cutting_time' is required and must match bet an integer between 15 and 120 to simulate the time taken for a haircut
                'price' => 'required|numeric', // 'price' is required and must be a numeric value
                'photo' => 'nullable|image|max:2048' // 'photo' is optional, must be an image file, and cannot exceed 2048 kilobytes in size
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Create a new Haircut instance and fill it with request data
            $haircut = new Haircut();
            $haircut->name = $request->input('name');
            $haircut->description = $request->input('description');
            $haircut->long_short = $request->input('long_short');
            $haircut->cutting_time = $request->input('cutting_time');
            $haircut->price = $request->input('price');
            // Check if the request includes a 'photo' file
            if ($request->hasFile('photo')) {
                // If a photo is included, store it in the 'haircut_photos' directory within the public disk and set the Haircut's photo attribute to the path of the stored file
                $photoPath = $request->file('photo')->store('haircut_photos', 'public');
                $haircut->photo_path = $photoPath;
            }
            // Save the Haircut to the database
            $haircut->save();
            // Return a JSON response with a code 200 status, indicating a successful insertion, and including the inserted Haircut details, formatted using ApiResponse::format
            //return ApiResponse::format('haircut', new HaircutResource($haircut), 200);
            return response()->json(new HaircutResource($haircut), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and updates an existing Haircut record by ID based on the provided request data.
    *
    * @param \Illuminate\Http\Request $request Request object containing the data for updating a Haircut.
    * @param string $id The ID of the Haircut to update.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the updated Haircut model, formatted using ApiResponse::format with HaircutResource to ensure consistency and accuracy of the API response.
    * If successful, it returns a JSON response with a code 200 status, indicating a successful update and including the formatted details of the updated Haircut.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * If the Haircut is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the updating process, it returns a JSON response with a code 500 status.
    */
    public function updateHaircut(Request $request, $id)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'name' => 'required|max:255|unique:haircuts,name,'.$id, // 'name' is required, must not exceed 255 characters, and must be unique in the 'haircuts' table (but can be the same as old one)
                'description' => 'nullable|max:255', // 'description' is optional but must not exceed 255 characters if provided
                'long_short' => 'required|boolean', // 'long_short' is required and must be a boolean value (true or false)
                'cutting_time' => 'required|integer|between:15,120', // // 'cutting_time' is required and must match bet an integer between 15 and 120 to simulate the time taken for a haircut
                'price' => 'required|numeric', // 'price' is required and must be a numeric value
                'photo' => 'nullable|image|max:2048' // 'photo' is optional, must be an image file, and cannot exceed 2048 kilobytes in size
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Attempt to find the Haircut by its ID. If not found, a ModelNotFoundException is thrown
            $haircut = Haircut::findOrFail($id);
            // Update the Haircut with request data
            $haircut->name = $request->input('name');
            $haircut->description = $request->input('description');
            $haircut->long_short = $request->input('long_short');
            $haircut->cutting_time = $request->input('cutting_time');
            $haircut->price = $request->input('price');
            // Check if the request includes a 'photo' file
            if ($request->hasFile('photo')) {
                // If a photo is included, store it in the 'haircut_photos' directory within the public disk and set the Haircut's photo attribute to the path of the stored file
                $photoPaths = $request->file('photo')->store('haircut_photos', 'public');
                $haircut->photo_path = $photoPath;
            }
            // Save the updated Haircut to the database
            $haircut->save();
            // Return a JSON response with a code 200 status, indicating a successful update, and including the updated Haircut details, formatted using ApiResponse::format
            //return ApiResponse::format('haircut', new HaircutResource($haircut), 200);
            return response()->json(new HaircutResource($haircut), 200);
        } catch (ModelNotFoundException $e) {
            // If the Haircut is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Haircut) does not exist
            return response()->json(['message' => 'Haircut not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Deletes a Haircut record by ID from the database and returns a JSON response
    * This method checks for dependencies (linked Stylists and Customers) that would prevent the deletion and handles any errors or exceptions by returning appropriate JSON responses
    * 
    * @param string $id The ID of the Haircut to be deleted.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response indicating the outcome of the operation
    * If successful, it returns a JSON response with a code 200 status, indicating successful deletion
    * If there are linked entities preventing deletion, it returns a JSON response with a code 422 status, detailing the dependencies
    * If the Haircut is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the deletion process, it returns a JSON response with a code 500 status.
    */
    public function destroyHaircut($id)
    {
        try {
            // Attempt to find the Haircut by its ID. If not found, a ModelNotFoundException is thrown
            $haircut = Haircut::with(['stylists', 'customers'])->findOrFail($id);
            // Prepare error messages if the Haircut cannot be deleted
            $errorMessages = [];
            // Check for linked stylists
            if ($haircut->stylists()->exists()) {
                foreach ($haircut->stylists as $stylist) {
                    $errorMessages[] = "Stylist " . $stylist->name . " " . $stylist->firstname . " (id:" . $stylist->id . ") is still linked to this haircut.";
                }
            }
            // Check for linked Customers
            if ($haircut->customers()->exists()) {
                foreach ($haircut->customers as $customer) {
                    $errorMessages[] = "Customer " . $customer->name . " " . $customer->firstname . " (id:" . $customer->id . ") still has this haircut.";
                }
            }
            // If there are any errors, return them in the response
            if (!empty($errorMessages)) {
                return response()->json([
                    'message' => 'Cannot delete haircut due to linked stylists or customers',
                    'errors' => $errorMessages
                ], 422);
            }
            // Check if the Haircut has an associated photo
            if ($haircut->photo_path) {
                // Delete the photo from the storage
                Storage::delete('public/' . $haircut->photo_path);
            }
            // Delete the found Haircut from the database
            $haircut->delete();
            // Return a JSON response with a code 200 status, indicating successful deletion
            return response()->json(['message' => 'Haircut deleted successfully', 'haircut_id' => $haircut->id], 200);
        } catch (ModelNotFoundException $e){
            // If the Haircut is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Haircut) does not exist
            return response()->json(['message' => 'Haircut not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

}
