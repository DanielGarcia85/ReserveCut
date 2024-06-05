<?php

// Specify the namespace for API controllers to structure and organize controller classes
namespace App\Http\Controllers\Api;

// Extend from the base Controller class to inherit base functionalities
use App\Http\Controllers\Controller;
// Import the Request class to handle HTTP requests in the controller methods
use Illuminate\Http\Request;
// Import the HaircutService to handle the business logic related to Haircut
use App\Http\Services\HaircutService;
// Import the HaircutResource to transform and format the Haircut model data for API responses
use App\Http\Resources\HaircutResource;

/**
 * Controller class for handling Haircut-related API requests.
 */
class HaircutController
{
    /**
     * Injects HaircutService for handling business logic.
     */
    public function __construct(private HaircutService $_haircutService){}

    /**
     * Retrieves all Haircuts and returns them as a collection of resources.
     * 
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing a collection of Haircut resources.
     */
    public function index()
    {
        try{
            // Retrieve all Haircuts using the HaircutService and return it wrapped in a resource
            return $this->_haircutService->indexHaircut();
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Displays a specific Haircut.
     * 
     * @param string $id / Parameter representing the Haircut ID.
     * @return \Illuminate\Http\JsonResponse Return type specifying a JSON response containing a single Haircut resource.
     */
    public function show(string $id)
    {
        try{
            // Retrieve the specific Haircut using its ID and return it wrapped in a resource
            return $this->_haircutService->showHaircut($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Stores a newly created Haircut in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the created Haircut resource.
     */
    public function store(Request $request)
    {
        try{
            // Store the new Haircut and return the created instance and return it wrapped in a resource
            return $this->_haircutService->storeHaircut($request);;
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Updates the specified Haircut in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @param string $id // Parameter representing the Haircut ID.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the updated Haircut resource.
     */
    public function update(Request $request, string $id)
    {
        try{
            // Update the specific Haircut and return the updated instance and return it wrapped in a resource
            return $this->_haircutService->updateHaircut($request, $id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Removes the specified Haircut from the database.
     * 
     * @param string $id // Parameter representing the Hairuct ID.
     * @return HaircutResource // Return type specifying the Hairuct resource after removal.
     */
    public function destroy(string $id)
    {
        try{
            // Calls the destroyHaircut method in the service layer with the ID and returns the response
            return $this->_haircutService->destroyHaircut($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }
}
