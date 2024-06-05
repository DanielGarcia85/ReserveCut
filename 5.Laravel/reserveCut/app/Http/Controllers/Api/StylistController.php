<?php

// Specify the namespace for API controllers to structure and organize controller classes
namespace App\Http\Controllers\Api;

// Extend from the base Controller class to inherit base functionalities
use App\Http\Controllers\Controller;
// Import the Request class to handle HTTP requests in the controller methods
use Illuminate\Http\Request;
// Import the StylistService to handle the business logic related to Stylist
use App\Http\Services\StylistService;
// Import the StylistResource to transform and format the Stylist model data for API responses
use App\Http\Resources\StylistResource;

/**
 * Controller class for handling Stylist-related API requests.
 */ 
class StylistController
{
    /**
     * Injects StylistService for handling business logic.
     */ 
    public function __construct(private StylistService $_stylistService){}

    /**
     * Retrieves all Stylists and returns them as a collection of resources.
     * 
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing a collection of Stylist resources.
     */
    public function index()
    {
        try{
            // Retrieve all Stylists using the StylistService and return it wrapped in a resource
            return $this->_stylistService->indexStylist();
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }
    
    /**
     * Displays a specific Stylist.
     * 
     * @param string $id / Parameter representing the Stylist ID.
     * @return \Illuminate\Http\JsonResponse Return type specifying a JSON response containing a single Stylist resource.
     */
    public function show(string $id)
    {
        try{
            // Retrieve the Stylist by ID using the StylistService and return it wrapped in a resource
            return $this->_stylistService->showStylist($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

     /**
     * Stores a newly created Stylist in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the created Stylist resource.
     */
    public function store(Request $request)
    {
        try{
            // Store the new Stylist and return the created instance and return it wrapped in a resource
            return $this->_stylistService->storeStylist($request);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Updates the specified Stylist in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @param string $id // Parameter representing the Stylist ID.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the updated Stylist resource.
     */
    public function update(Request $request, string $id)
    {
        try{
            // Update the specific Stylist and return the updated instance and return it wrapped in a resource
            return $this->_stylistService->updateStylist($request, $id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Removes the specified Stylist from the database.
     * 
     * @param string $id // Parameter representing the Stylist ID.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response after removal.
     */
    public function destroy(string $id)
    {
        try{
            // Calls the destroyStylist method in the service layer with the ID and returns the response
            return $this->_stylistService->destroyStylist($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }
}
