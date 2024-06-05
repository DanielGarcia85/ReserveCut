<?php

// Specify the namespace for API controllers to structure and organize controller classes
namespace App\Http\Controllers\Api;

// Extend from the base Controller class to inherit base functionalities
use App\Http\Controllers\Controller;
// Import the Request class to handle HTTP requests in the controller methods
use Illuminate\Http\Request;
// Import the ReservationService to handle the business logic related to Reservation
use App\Http\Services\ReservationService;
// Import the ReservationResource to transform and format the Reservation model data for API responses
use App\Http\Resources\ReservationResource;

/**
 * Controller class for handling Reservation-related API requests
 */
class ReservationController
{
    /**
     * Injects ReservationService for handling business logic.
     */
    public function __construct(private ReservationService $_reservationService){}

    /**
     * Retrieves all Reservations and returns them as a collection of resources.
     * 
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing a collection of Reservation resources.
     */
    public function index()
    {
        try{
            // Retrieve all Reservations using the ReservationService and return it wrapped in a resource
            return $this->_reservationService->indexReservation();
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Displays a specific Reservation.
     * 
     * @return \Illuminate\Http\JsonResponse Return type specifying a JSON response containing a single Reservation resource.
     * @return ReservationResource // Return type specifying a single Reservation resource.
     */
    public function show(string $id)
    {
        try{
            // Retrieve the specific Reservation using its ID and return it wrapped in a resource
            return $this->_reservationService->showReservation($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Stores a newly created Reservation in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the created Reservation resource.
     */
    public function store(Request $request)
    {
        try{
            // Store the new Reservation and return the created instance and return it wrapped in a resource
            return $this->_reservationService->storeReservation($request);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Updates the specified Reservation in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @param string $id // Parameter representing the Reservation ID.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the updated Reservation resource.
     */
    public function update(Request $request, string $id)
    {
        try{
            // Update the specific Reservation and return the updated instance and return it wrapped in a resource
            return $this->_reservationService->updateReservation($request, $id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
    * Removes the specified Reservation from the database.
    * 
    * @param string $id // Parameter representing the Reservation ID.
    * @return \Illuminate\Http\JsonResponse // Return type specifying the Reservation resource after removal.
    */
    public function destroy(string $id)
    {
        try{
            // Calls the destroyReservation method in the service layer with the ID and returns the response
            return $this->_reservationService->destroyReservation($id);
        } catch(\Exception $e){
            // Throws an exception if an error occurs
            throw $e;
        }
    }
}
