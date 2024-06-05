<?php

// Specify the namespace for HTTP service classes to organize service-related classes
namespace App\Http\Services;

// Import the Reservation model to interact with Reservation's data in the database
use App\Models\Reservation;
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
// Imports the ApiResponse helper class to standardize and simplify the creation of JSON responses throughout the application
use App\Http\Middleware\ApiResponse;

/**
 * Define the service class for handling Reservation operations
 */
class ReservationService
{
    /**
    * Retrieves and returns all Reservations along with its associated Customer and Stylist from the database
    *
    * @return \Illuminate\Http\JsonResponse // Returns a JSON response containing a collection of Reservation models with related Customer and Stylist, formatted using ApiResponse::format with ReservationResource to ensure consistency and accuracy of the API response
    * @throws \Symfony\Component\HttpKernel\Exception\HttpException Throws an HTTP exception with a 500 status code if there's an error during the fetching process
    */
    public function indexReservation()
    {
        try {
            // Return all Reservations records from the database, with its related Customer and Ctylist
            $reservations = Reservation::with(['customer', 'stylist'])->get();
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including all the retrieved Reservations details, formatted using ApiResponse::format
            //return ApiResponse::format('reservations', ReservationResource::collection($reservations), 200);
            return response()->json(ReservationResource::collection($reservations), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Retrieves and returns a single Reservation along with its associated Customer and Stylist from the database by the Reservation's ID.
    * This method ensures that the returned Reservation is formatted using ApiResponse::format with ReservationResource to ensure consistency and accuracy of the API response.
    *
    * @param string $id The ID of the Reservation to retrieve.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the specific Reservation model, including details about associated  Customer and Stylist. If successful, it returns a JSON response with a code 200 status.
    * If the Reservation is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the retrieval process, it returns a JSON response with a code 500 status.
    */
    public function showReservation($id)
    {
        try {
            // Attempt to find the Reservation by its ID, including Customer and Stylist. If not found, a ModelNotFoundException is thrown
            $reservation = Reservation::with(['customer', 'stylist'])->findOrFail($id);
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including the retrieved Reservation details, formatted using ApiResponse::format
            //return ApiResponse::format('reservation', new ReservationResource($reservation), 200);
            return response()->json(new ReservationResource($reservation), 200);
        } catch (ModelNotFoundException $e) {
            // If the Reservation is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Reservation) does not exist
            return response()->json(['message' => 'Reservation not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and stores a new Reservation record based on the provided request data.
    * This method ensures data validation and handles errors or exceptions by returning appropriate JSON responses.
    * 
    * @param \Illuminate\Http\Request $request Request object containing the data for creating a Reservation.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the newly created Reservation model. If the creation is successful, formatted using ApiResponse::format with ReservationResource to ensure consistency and accuracy of the API response.
    * If the validation is successful, it returns a JSON response with a code 200 status, indicating successful insertion.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * For any other errors during the saving process, it returns a JSON response with a code 500 status.
    */
    public function storeReservation(Request $request)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'customer_id' => 'required|exists:customers,id', // 'customer_id' must be provided and must exist in the 'customers' table
                'stylist_id' => 'required|exists:stylists,id', // 'stylist_id' is required and must exist in the 'stylists' table
                'date_begin' => 'required|date', // 'date_begin' must be provided with a time and must be a valid date
                'date_end' => 'required|date|after:date_begin', // 'date_end' is required, must be a valid date with a time, and must be after 'date_begin'
                'comments' => 'nullable|string|max:255', // 'comments' is optional, must be a string, and cannot exceed 255 characters
                'beard_y_n' => 'required|boolean', // 'beard_y_n' is required and must be a boolean (true or false)
                'shampoo_y_n' => 'required|boolean' // 'shampoo_y_n' must be provided and be a boolean value
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                return response()->json(['errors' => $validator->errors()], 422);
            }/*
            $stylistId = $request->input('stylist_id');
            $customerId = $request->input('customer_id');
            $dateBegin = $request->input('date_begin');
            $dateEnd = $request->input('date_end');
            // Check if there is already a reservation for the stylist at the same time
            $existingReservation = Reservation::where('stylist_id', $stylistId)
            ->where(function ($query) use ($dateBegin, $dateEnd) {
                $query->whereBetween('date_begin', [$dateBegin, $dateEnd])
                    ->orWhereBetween('date_end', [$dateBegin, $dateEnd])
                    ->orWhere(function ($query) use ($dateBegin, $dateEnd) {
                    $query->where('date_begin', '<=', $dateBegin)
                            ->where('date_end', '>=', $dateEnd);
                    });
                })
                ->first();
            if ($existingReservation) {
                return response()->json(['message' => 'The stylist already has a reservation at this time.'], 409);
            }
            // Check if the reservation is during an absence of the stylist
            $absence = Absence::where('stylist_id', $stylistId)
            ->where(function ($query) use ($dateBegin, $dateEnd) {
                $query->whereBetween('date_begin', [$dateBegin, $dateEnd])
                    ->orWhereBetween('date_end', [$dateBegin, $dateEnd])
                    ->orWhere(function ($query) use ($dateBegin, $dateEnd) {
                        $query->where('date_begin', '<=', $dateBegin)
                            ->where('date_end', '>=', $dateEnd);
                    });
                })
                ->first();
            if ($absence) {
                return response()->json(['message' => 'The stylist is absent at this time.'], 409);
            }
            // Check if the customer already has a reservation at the same time
            $existingCustomerReservation = Reservation::where('customer_id', $customerId)
            ->where(function ($query) use ($dateBegin, $dateEnd) {
                $query->whereBetween('date_begin', [$dateBegin, $dateEnd])
                    ->orWhereBetween('date_end', [$dateBegin, $dateEnd])
                    ->orWhere(function ($query) use ($dateBegin, $dateEnd) {
                        $query->where('date_begin', '<=', $dateBegin)
                            ->where('date_end', '>=', $dateEnd);
                    });
                })
                ->first();
            if ($existingCustomerReservation) {
                return response()->json(['message' => 'The customer already has a reservation at this time.'], 409);
            }*/
            // Create a new Reservation instance and fill it with request data
            $reservation = new Reservation();
            $reservation->customer_id = $request->input('customer_id');
            $reservation->stylist_id = $request->input('stylist_id');
            $reservation->date_begin = $request->input('date_begin');
            $reservation->date_end = $request->input('date_end');
            $reservation->comments = $request->input('comments');
            $reservation->beard_y_n = $request->input('beard_y_n');
            $reservation->shampoo_y_n = $request->input('shampoo_y_n');
            // Save the Reservation to the database
            $reservation->save();
            // Return a JSON response with a code 200 status, indicating a successful insertion
            return response()->json(new ReservationResource($reservation), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }


     /**
    * Validates and updates an existing Reservation record by ID based on the provided request data, including associated Customer and Stylist.
    *
    * @param \Illuminate\Http\Request $request Request object containing the data for updating a Reservation.
    * @param string $id The ID of the Reservation to update.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the updated Reservation model including details about associated Customer and Stylist, formatted using ApiResponse::format with ReservationResource to ensure consistency and accuracy of the API response.
    * If successful, it returns a JSON response with a code 200 status, indicating a successful update and including the formatted details of the updated Reservation.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * If the Reservation is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the updating process, it returns a JSON response with a code 500 status.
    */
    public function updateReservation(Request $request, $id)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'customer_id' => 'required|exists:customers,id', // 'customer_id' must be provided and must exist in the 'customers' table
                'stylist_id' => 'required|exists:stylists,id', // 'stylist_id' is required and must exist in the 'stylists' table
                'date_begin' => 'required|date', // 'date_begin' must be provided with a time and must be a valid date
                'date_end' => 'required|date|after:date_begin', // 'date_end' is required, must be a valid date with a time, and must be after 'date_begin'
                'comments' => 'nullable|string|max:255', // 'comments' is optional, must be a string, and cannot exceed 255 characters
                'beard_y_n' => 'required|boolean', // 'beard_y_n' is required and must be a boolean (true or false)
                'shampoo_y_n' => 'required|boolean' // 'shampoo_y_n' must be provided and be a boolean value
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            /*
            $stylistId = $request->input('stylist_id');
            $customerId = $request->input('customer_id');
            $dateBegin = $request->input('date_begin');
            $dateEnd = $request->input('date_end');            
            // Check if there is already a reservation for the stylist at the same time
            $existingReservation = Reservation::where('stylist_id', $stylistId)
            ->where('id', '!=', $id)
            ->where(function ($query) use ($dateBegin, $dateEnd) {
                $query->whereBetween('date_begin', [$dateBegin, $dateEnd])
                    ->orWhereBetween('date_end', [$dateBegin, $dateEnd])
                    ->orWhere(function ($query) use ($dateBegin, $dateEnd) {
                        $query->where('date_begin', '<=', $dateBegin)
                            ->where('date_end', '>=', $dateEnd);
                    });
                })
                ->first();
            if ($existingReservation) {
                return response()->json(['message' => 'The stylist already has a reservation at this time.'], 409);
            }
            // Check if the reservation is during an absence of the stylist
            $absence = Absence::where('stylist_id', $stylistId)
            ->where(function ($query) use ($dateBegin, $dateEnd) {
                $query->whereBetween('date_begin', [$dateBegin, $dateEnd])
                    ->orWhereBetween('date_end', [$dateBegin, $dateEnd])
                    ->orWhere(function ($query) use ($dateBegin, $dateEnd) {
                        $query->where('date_begin', '<=', $dateBegin)
                            ->where('date_end', '>=', $dateEnd);
                    });
                })
                ->first();
            if ($absence) {
                return response()->json(['message' => 'The stylist is absent at this time.'], 409);
            }
            // Check if the customer already has a reservation at the same time
            $existingCustomerReservation = Reservation::where('customer_id', $customerId)
                ->where('id', '!=', $id)
                ->where(function ($query) use ($dateBegin, $dateEnd) {
                    $query->whereBetween('date_begin', [$dateBegin, $dateEnd])
                        ->orWhereBetween('date_end', [$dateBegin, $dateEnd])
                        ->orWhere(function ($query) use ($dateBegin, $dateEnd) {
                            $query->where('date_begin', '<=', $dateBegin)
                                ->where('date_end', '>=', $dateEnd);
                        });
                    })
                ->first();
            if ($existingCustomerReservation) {
                return response()->json(['message' => 'The customer already has a reservation at this time.'], 409);
            }
            */
            // Attempt to find the Reservation by its ID. If not found, a ModelNotFoundException is thrown
            $reservation = Reservation::findOrFail($id);
            // Update the Reservation with request data
            $reservation->customer_id = $request->input('customer_id');
            $reservation->stylist_id = $request->input('stylist_id');
            $reservation->date_begin = $request->input('date_begin');
            $reservation->date_end = $request->input('date_end');
            $reservation->comments = $request->input('comments');
            $reservation->beard_y_n = $request->input('beard_y_n');
            $reservation->shampoo_y_n = $request->input('shampoo_y_n');
            // Save the updated Reservation to the database
            $reservation->save();
            // Return a JSON response with a code 200 status, indicating a successful update, and including the updated Reservation details, formatted using ApiResponse::format
            //return ApiResponse::format('reservation', new ReservationResource($reservation), 200);
            return response()->json(new ReservationResource($reservation), 200);
        } catch (ModelNotFoundException $e) {
            // If the Reservation is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Reservation) does not exist
            return response()->json(['message' => 'Reservation not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Deletes a Reservation record by ID from the database and returns a JSON response.
    * This method checks for dependencies that would prevent the deletion and handles any errors or exceptions by returning appropriate JSON responses.
    *
    * @param string $id The ID of the Reservation to be deleted.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response indicating the outcome of the operation.
    * If successful, it returns a JSON response with a code 200 status, indicating successful deletion.
    * If the Reservation is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the deletion process, it returns a JSON response with a code 500 status.
    */
    public function destroyReservation($id)
    {
        try {
            // Attempt to find the Reservation by its ID. If not found, a ModelNotFoundException is thrown
            $reservation = Reservation::findOrFail($id);
            // Delete the found Reservation from the database
            $reservation->delete();
            // Return a JSON response with a code 200 status, indicating successful deletion
            return response()->json(['message' => 'Reservation deleted successfully', 'reservation_id' => $reservation->id], 200);
        } catch (ModelNotFoundException $e){
            // If the Reservation is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (Reservation) does not exist
            return response()->json(['message' => 'Reservation not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

}
