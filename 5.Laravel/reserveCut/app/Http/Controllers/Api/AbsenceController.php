<?php

// Specify the namespace for API controllers to structure and organize controller classes
namespace App\Http\Controllers\Api;

// Extend from the base Controller class to inherit base functionalities
use App\Http\Controllers\Controller;
// Import the Request class to handle HTTP requests in the controller methods
use Illuminate\Http\Request;
// Import the AbsenceService to handle the business logic related to Absence
use App\Http\Services\AbsenceService;
// Import the AbsenceResource to transform and format the Absence model data for API responses
use App\Http\Resources\AbsenceResource;

/**
 * Controller class for handling Absence-related API requests
 */
class AbsenceController
{
    /**
     * Injects AbsenceService for handling business logic.
     */
    public function __construct(private AbsenceService $_absenceService){}

    /**
     * Retrieves all Absences and returns them as a collection of resources.
     * 
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing a collection of Absence resources.
     */
    public function index()
    {
        try{
            // Retrieve all Absences using the AbsenceService and return it wrapped in a resource
            return $this->_absenceService->indexAbsence();
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

     /**
     * Displays a specific Absence.
     * 
     * @param string $id // Parameter representing the Absence ID.
     * @return \Illuminate\Http\JsonResponse Return type specifying a JSON response containing a single Absence resource.
     */
    public function show(string $id)
    {
        try{
            // Retrieve the specific Absence using its ID and return it wrapped in a resource
            return $this->_absenceService->showAbsence($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Stores a newly created Absence in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the created Absence resource.
     */
    public function store(Request $request)
    {
        try{
            // Store the new Absence and return the created instance and return it wrapped in a resource
            return $this->_absenceService->storeAbsence($request);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Updates the specified Absence in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @param string $id // Parameter representing the Absence ID.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the updated Absence resource.
     */
    public function update(Request $request, string $id)
    {
        try{
            // Update the specific Absence and return the updated instance and return it wrapped in a resource
            return $this->_absenceService->updateAbsence($request, $id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Removes the specified Absence from the database.
     * 
     * @param string $id // Parameter representing the Absence ID.
     * @return AbsenceResource // Return type specifying the Absence resource after removal.
     */
    public function destroy(string $id)
    {
        try{
            // Calls the destroyAbsence method in the service layer with the ID and returns the response
            return $this->_absenceService->destroyAbsence($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }
}
