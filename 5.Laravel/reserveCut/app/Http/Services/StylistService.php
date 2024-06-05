<?php

// Specify the namespace for HTTP service classes to organize service-related classes
namespace App\Http\Services;

// Import the Stylist model to interact with Stylist's data in the database
use App\Models\Stylist;
// Import the Absence model to interact with Absence's data in the database
use App\Models\Absence;
// Import the Request class to handle HTTP requests in service methods
use Illuminate\Http\Request;
// Import the Validator facade to validate incoming data against specific rules
use Illuminate\Support\Facades\Validator;
// Import the ModelNotFoundException for handling cases where a model instance isn't found in the database
use Illuminate\Database\Eloquent\ModelNotFoundException;
// Imports the ReservationResource class, which provides a means to format and return Reservation data structures for API responses
use App\Http\Resources\ReservationResource;
// Imports the AbsenceResource class, which provides a means to format and return Absence data structures for API responses
use App\Http\Resources\AbsenceResource;
// Imports the StylistResource class, which provides a means to format and return Stylist data structures for API responses
use App\Http\Resources\StylistResource;
// Imports the ApiResponse helper class to standardize and simplify the creation of JSON responses throughout the application
use App\Http\Middleware\ApiResponse;
// Use the Storage facade to interact with the filesystem
use Illuminate\Support\Facades\Storage;


/**
 * Define the service class for handling Stylist operations
 */
class StylistService
{
    /**
    * Retrieves and returns all Stylists along with their associated Haircuts, Reservations, and Absences from the database.
    * This method ensures that the returned collection of Stylist models is formatted using ApiResponse::format with StylistResource to ensure consistency and accuracy of the API response.
    *
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing a collection of Stylist models, each including details about associated Haircuts, Reservations, and Absences. The data is formatted for API consistency and accuracy.
    * If there's an error during the fetching process, it returns a JSON response with a code 500 status.
    */
    public function indexStylist()
    {
        try {
            // 
            $stylists = Stylist::with('haircuts', 'reservations', 'absences')->get();
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including all the retrieved Stylists details, formatted using ApiResponse::format
            //return ApiResponse::format('stylists', StylistResource::collection($stylists), 200);
            return response()->json(StylistResource::collection($stylists), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Retrieves and returns a single Stylist along with its associated Haircuts, Reservations, and Absences from the database by the Stylist's ID.
    * This method ensures that the returned Stylist is formatted using ApiResponse::format with StylistResource to ensure consistency and accuracy of the API response.
    *
    * @param string $id The ID of the Stylist to retrieve.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the specific Stylist model, including details about associated Haircuts, Reservations, and Absences. If successful, it returns a JSON response with a code 200 status.
    * If the Stylist is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the retrieval process, it returns a JSON response with a code 500 status.
    */
    public function showStylist(String $id)
    {
        try {
            // Attempt to find the Stylist by its ID, including related Haircuts, Reservations and Absences. If not found, a ModelNotFoundException is thrown
            $stylist = Stylist::with('haircuts', 'reservations', 'absences')->findOrFail($id);
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including the retrieved Stylist details, formatted using ApiResponse::format
            //return ApiResponse::format('stylist', new StylistResource($stylist), 200);
            return response()->json(new StylistResource($stylist), 200);
        } catch (ModelNotFoundException $e){
            // If the Stylist is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Stylist) does not exist
            return response()->json(['message' => 'Stylist not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and stores a new Stylist record based on the provided request data, including associating Haircuts if specified.
    * This method ensures data validation and handles errors or exceptions by returning appropriate JSON responses.
    * 
    * @param \Illuminate\Http\Request $request Request object containing the data for creating a Stylist and associating Haircuts.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the newly created Stylist model. If the creation is successful, it includes details about associated Haircuts, formatted using ApiResponse::format with StylistResource to ensure consistency and accuracy of the API response.
    * If the validation is successful, it returns a JSON response with a code 200 status, indicating successful insertion.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * For any other errors during the saving process, it returns a JSON response with a code 500 status.
    */
    public function storeStylist(Request $request)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'name' => 'required|max:64', // 'name' must be provided and cannot exceed 64 characters
                'firstname' => 'required|max:64', // 'firstname' is required and must not be longer than 64 characters
                'photo' => 'nullable|image|max:2048', // 'photo' is optional but must be an image and cannot be larger than 2048 kilobytes
                'haircut_ids*' => 'nullable|exists:haircuts,id' // Ensure each 'haircut_id' exists in the 'haircuts' table
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Create a new Stylist instance and fill it with request data
            $stylist = new Stylist();
            $stylist->name = $request->input('name');
            $stylist->firstname = $request->input('firstname');
            // Check if the request includes a 'photo' file
            if ($request->hasFile('photo')) {
                // If a photo is included, store it in the 'stylist_photos' directory within the public disk and set the Stylist's photo attribute to the path of the stored file
                $photoPath = $request->file('photo')->store('stylist_photos', 'public');
                $stylist->photo_path = $photoPath;
            }
            // Save the Stylist to the database
            $stylist->save();
            // Retrieve the associated Haircuts from the database using the haircut_ids provided in the request
            $haircutIds = $request->input('haircut_ids');
            // Ensure haircutIds is not empty and is always an array
            if(!empty($haircutIds)){
                if (is_string($haircutIds)) {
                    $haircutIds = explode(',', $haircutIds); // Assuming comma-separated values if passed as a single string
                }
                $haircutIds = array_unique($haircutIds); // Remove duplicates
                // Attach the related Haircuts to the Stylist, establishing their relationships in the database
                foreach ($haircutIds as $haircutId) {
                    $stylist->haircuts()->attach($haircutId);
                }
            }
            // Load the Haircuts relationship to include in the return
            $stylist->load('haircuts');
            // Return a JSON response with a code 200 status, indicating a successful insertion, and including the inserted Stylist details, formatted using ApiResponse::format
            //return ApiResponse::format('stylist', new StylistResource($stylist), 200);
            return response()->json(new StylistResource($stylist), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and updates an existing Stylist record by ID based on the provided request data, including associated Haircuts and Absences if specified.
    *
    * @param \Illuminate\Http\Request $request Request object containing the data for updating a Stylist.
    * @param string $id The ID of the Stylist to update.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the updated Stylist model including details about associated Haircuts and Absences, formatted using ApiResponse::format with StylistResource to ensure consistency and accuracy of the API response.
    * If successful, it returns a JSON response with a code 200 status, indicating a successful update and including the formatted details of the updated Stylist.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * If the Stylist is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the updating process, it returns a JSON response with a code 500 status.
    */
    public function updateStylist(Request $request, String $id)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'name' => 'required|max:64', // 'name' must be provided and cannot exceed 64 characters
                'firstname' => 'required|max:64', // 'firstname' is required and must not be longer than 64 characters
                'photo' => 'nullable|image|max:2048' // 'photo' is optional but must be an image and cannot be larger than 2048 kilobytes
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Attempt to find the Stylist by its ID. If not found, a ModelNotFoundException is thrown
            $stylist = Stylist::findOrFail($id);
            // Update the Stylist with request data
            $stylist->name = $request->input('name');
            $stylist->firstname = $request->input('firstname');
            // Check if the request includes a 'photo' file
            if ($request->hasFile('photo')) {
                // If a photo is included, store it in the 'stylist_photos' directory within the public disk and set the Stylist's photo attribute to the path of the stored file
                $photoPath = $request->file('photo')->store('stylist_photos', 'public');
                $stylist->photo_path = $photoPath;
            }
            // Save the updated Stylist to the database
            $stylist->save();
            // Retrieve the associated Haircuts from the database using the haircut_ids provided in the request
            $haircutIds = $request->input('haircut_ids');
            // Ensure haircutIds is not empty and is always an array
            if(!empty($haircutIds)){
                if (is_string($haircutIds)) {
                    $haircutIds = explode(',', $haircutIds); // Assuming comma-separated values if passed as a single string
                }
                // Synchronize the related Haircuts to the Stylist, establishing their relationships in the database
                $stylist->haircuts()->sync($haircutIds);
            }
            // Retrieve the associated Absences from the database using the absence_ids provided in the request
            $absenceIds = $request->input('absence_ids', []);
             // Ensure absenceIds is not empty and is always an array
            if (!empty($absenceIds)) {
                if (is_string($absenceIds)) {
                    $absenceIds = explode(',', $absenceIds);
                }
                // Update or clear the stylist_id for related absences
                Absence::whereIn('id', $absenceIds)
                    ->update(['stylist_id' => $stylist->id]); // Assign the stylist to the absences
                Absence::where('stylist_id', $stylist->id)
                    ->whereNotIn('id', $absenceIds)
                    ->delete(); // Remove the stylist from other absences
            }
            // Reload to include updated relationships
            $stylist->load('haircuts', 'absences');
            // Return a JSON response with a code 200 status, indicating a successful update, and including the updated Stylist details, formatted using ApiResponse::format
            //return ApiResponse::format('stylist', new StylistResource($stylist), 200);
            return response()->json(new StylistResource($stylist), 200);
        } catch (ModelNotFoundException $e) {
            // If the Stylist is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Stylist) does not exist
            return response()->json(['message' => 'Stylist not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Deletes a Haircut record by ID from the database and returns a JSON response.
    * This method checks for dependencies (linked Reservation and Absences) that would prevent the deletion and handles any errors or exceptions by returning appropriate JSON responses.
    *
    * @param string $id The ID of the Haircut to be deleted.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response indicating the outcome of the operation.
    * If successful, it returns a JSON response with a code 200 status, indicating successful deletion.
    * If there are linked entities preventing deletion, it returns a JSON response with a code 422 status, detailing the dependencies.
    * If the Haircut is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the deletion process, it returns a JSON response with a code 500 status.
    */
    public function destroyStylist(String $id)
    {
        try {
            // Attempt to find the Stylist by its ID including related reservations and absences. If not found, a ModelNotFoundException is thrown
            $stylist = Stylist::with('reservations', 'absences')->findOrFail($id);
            // Prepare error messages if the Stylist cannot be deleted
            $errorMessages = [];
            // Check for linked Reservations
            if ($stylist->reservations()->exists()) {
                foreach ($stylist->reservations as $reservation) {
                    $errorMessages[] = "Reservation (id:" . $reservation->id . ") from " . $reservation->date_begin . " to " . $reservation->date_end;
                }
            }
            // Check for linked Absences
            if ($stylist->absences()->exists()) {
                foreach ($stylist->absences as $absence) {
                    $errorMessages[] = "Absence (id:" . $absence->id . ") from " . $absence->date_begin . " to " . $absence->date_end;
                }
            }
            // If there are errors related to linked Reservations or Absences preventing the deletion of the Stylist, return a JSON response with a code 422 status
            if (!empty($errorMessages)) {
                return response()->json([
                    'message' => 'Cannot delete stylist due to linked reservations or absences',
                    'errors' => $errorMessages
                ], 422);
            }
            // Detach all associated Haircuts before deleting the Stylist
            $stylist->haircuts()->detach();
            // Check if the Stylist has an associated photo
            if ($stylist->photo_path) {
                // Delete the photo from the storage
                Storage::delete('public/' . $stylist->photo_path);
            }
            // Delete the found Stylist from the database
            $stylist->delete();
            // Return a JSON response with a code 200 status, indicating successful deletion and the ID of the deleted Stylist
            return response()->json(['message' => 'Stylist deleted successfully', 'stylist_id' => $stylist->id], 200);
        } catch (ModelNotFoundException $e) {
            // If the Stylist is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Stylist) does not exist
            return response()->json(['message' => 'Stylist not found'], 404);

        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

}
