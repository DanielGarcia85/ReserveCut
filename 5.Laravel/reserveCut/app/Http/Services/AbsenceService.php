<?php

// Specify the namespace for HTTP service classes to organize service-related classes
namespace App\Http\Services;

// Import the Absence model to interact with Absence's data in the database
use App\Models\Absence;
// Import the Request class to handle HTTP requests in service methods
use Illuminate\Http\Request;
// Import the Validator facade to validate incoming data against specific rules
use Illuminate\Support\Facades\Validator;
// Import the ModelNotFoundException for handling cases where a model instance isn't found in the database
use Illuminate\Database\Eloquent\ModelNotFoundException;
// Imports the AbsenceResource class, which provides a means to format and return Absence data structures for API responses
use App\Http\Resources\AbsenceResource;
// Imports the ApiResponse helper class to standardize and simplify the creation of JSON responses throughout the application
use App\Http\Middleware\ApiResponse;

/**
 * Define the service class for handling Absence operations
 */
class AbsenceService
{
    /**
    * Retrieves and returns all Absences along with their associated Stylist from the database.
    * This method ensures that the returned collection of Absence models is formatted using ApiResponse::format with AbsenceResource to ensure consistency and accuracy of the API response.
    *
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing a collection of Absence models, each including details about associated Stylist. The data is formatted for API consistency and accuracy.
    * If there's an error during the fetching process, it returns a JSON response with a code 500 status.
    */
    public function indexAbsence()
    {
        try {
            // Return all Absences records from the database with its related Stylist
            $absences = Absence::with('stylist')->get();
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including all the retrieved Absences details, formatted using ApiResponse::format
            //return ApiResponse::format('absences', AbsenceResource::collection($absences), 200);
            return response()->json(AbsenceResource::collection($absences), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Retrieves and returns a single Absence along with its associated Stylist from the database by the Absence's ID.
    * This method ensures that the returned Absence is formatted using ApiResponse::format with AbsenceResource to ensure consistency and accuracy of the API response.
    *
    * @param string $id The ID of the Absence to retrieve.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the specific Absence model, including details about associated Stylist. If successful, it returns a JSON response with a code 200 status.
    * If the Absence is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the retrieval process, it returns a JSON response with a code 500 status.
    */
    public function showAbsence($id)
    {
        try {
            // Attempt to find the Absence by its ID including related Stylist. If not found, a ModelNotFoundException is thrown
            $absence = Absence::with('stylist')->findOrFail($id);
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including the retrieved Absence details, formatted using ApiResponse::format
            //return ApiResponse::format('absence', new AbsenceResource($absence), 200);
            return response()->json(new AbsenceResource($absence), 200);
        } catch (ModelNotFoundException $e){
            // If the Absence is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Absence) does not exist
            return response()->json(['message' => 'Absence not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and stores a new Absence record based on the provided request data, including associating Stylist.
    * This method ensures data validation and handles errors or exceptions by returning appropriate JSON responses.
    * 
    * @param \Illuminate\Http\Request $request Request object containing the data for creating a Absence and associating Stylist.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the newly created Absence model. If the creation is successful, it includes details about associated Stylist, formatted using ApiResponse::format with AbsenceResource to ensure consistency and accuracy of the API response.
    * If the validation is successful, it returns a JSON response with a code 200 status, indicating successful insertion.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * For any other errors during the saving process, it returns a JSON response with a code 500 status.
    */
    public function storeAbsence(Request $request)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'stylist_id' => 'required|exists:stylists,id', // 'stylist_id' is required and must exist in the 'stylists' table under the 'id' column
                'date_begin' => 'required|date', // 'date_begin' is required and must be a valid date format
                'date_end' => 'required|date|after:date_begin' // 'date_end' is required, must be a valid date format, and must occur after 'date_begin'
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Create a new Absence instance and fill it with request data
            $absence = new Absence();
            $absence->stylist_id = $request->input('stylist_id');
            $absence->date_begin = $request->input('date_begin');
            $absence->date_end = $request->input('date_end');
            // Save the Absence to the database
            $absence->save();
            // Return a JSON response with a code 200 status, indicating a successful insertion, and including the inserted Absence details, formatted using ApiResponse::format
            //return ApiResponse::format('absence', new AbsenceResource($absence), 200);
            return response()->json(new AbsenceResource($absence), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and updates an existing Absence record by ID based on the provided request data, including associated Stylist.
    *
    * @param \Illuminate\Http\Request $request Request object containing the data for updating a Absence.
    * @param string $id The ID of the Absence to update.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the updated Absence model including details about associated Stylist, formatted using ApiResponse::format with AbsenceResource to ensure consistency and accuracy of the API response.
    * If successful, it returns a JSON response with a code 200 status, indicating a successful update and including the formatted details of the updated Absence.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * If the Absence is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the updating process, it returns a JSON response with a code 500 status.
    */
    public function updateAbsence(Request $request, $id)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'stylist_id' => 'required|exists:stylists,id', // 'stylist_id' is required and must exist in the 'stylists' table under the 'id' column
                'date_begin' => 'required|date', // 'date_begin' is required and must be a valid date format
                'date_end' => 'required|date|after:date_begin' // 'date_end' is required, must be a valid date format, and must occur after 'date_begin'
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Attempt to find the Absence by its ID. If not found, a ModelNotFoundException is thrown
            $absence = Absence::findOrFail($id);
            // Update the Absence with request data
            $absence->stylist_id = $request->input('stylist_id');
            $absence->date_begin = $request->input('date_begin');
            $absence->date_end = $request->input('date_end');
            // Save the updated Absence to the database
            $absence->save();
            // Return a JSON response with a code 200 status, indicating a successful update, and including the updated Absence details, formatted using ApiResponse::format
            //return ApiResponse::format('absence', new AbsenceResource($absence), 200);
            return response()->json(new AbsenceResource($absence), 200);
        } catch (ModelNotFoundException $e) {
            // If the Absence is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Absence) does not exist
            return response()->json(['message' => 'Absence not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Deletes an Absence record by ID from the database and returns a JSON response.
    * This method checks for dependencies that would prevent the deletion and handles any errors or exceptions by returning appropriate JSON responses.
    *
    * @param string $id The ID of the Absence to be deleted.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response indicating the outcome of the operation.
    * If successful, it returns a JSON response with a code 200 status, indicating successful deletion.
    * If the Absence is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the deletion process, it returns a JSON response with a code 500 status.
    */
    public function destroyAbsence($id)
    {
        try {
            // Attempt to find the Absence by its ID. If not found, a ModelNotFoundException is thrown
            $absence = Absence::findOrFail($id);
            // Delete the found Absence from the database
            $absence->delete();
            // Return a JSON response with a code 200 status, indicating successful deletion
            return response()->json(['message' => 'Absence deleted successfully', 'absence_id' => $absence->id], 200);
        } catch (ModelNotFoundException $e){
            // If the Absence is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Absence) does not exist
            return response()->json(['message' => 'Absence not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

}
