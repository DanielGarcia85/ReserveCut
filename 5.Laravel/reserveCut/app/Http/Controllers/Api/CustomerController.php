<?php

// Specify the namespace for API controllers to structure and organize controller classes
namespace App\Http\Controllers\Api;

// Extend from the base Controller class to inherit base functionalities
use App\Http\Controllers\Controller;
// Import the Request class to handle HTTP requests in the controller methods
use Illuminate\Http\Request;
// Import the CustomerService to handle the business logic related to Customer
use App\Http\Services\CustomerService;
// Import the CustomerResource to transform and format the Customer model data for API responses
use App\Http\Resources\CustomerResource;

/**
 * Controller class for handling Customer-related API requests.
 */
class CustomerController
{
    /**
     * Injects CustomerService for handling business logic.
     */
    public function __construct(private CustomerService $_customerService){}

    /**
     * Retrieves all Customers and returns them as a collection of resources.
     * 
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing a collection of Customer resources.
     */
    public function index()
    {
        try{
            // Retrieve all Customers using the CustomerService and return it wrapped in a resource
            return $this->_customerService->indexCustomer();
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Displays a specific Customer.
     * 
     * @param string $id / Parameter representing the Customer ID.
     * @return \Illuminate\Http\JsonResponse Return type specifying a JSON response containing a single Customer resource.
     */
    public function show(string $id)
    {
        try{
            // Retrieve the specific Customer using its ID and return it wrapped in a resource
            return $this->_customerService->showCustomer($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }
    
    /**
     * Stores a newly created Customer in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the created Customer resource.
     */
    public function store(Request $request)
    {
        try{
            // Store the new Customer and return the created instance and return it wrapped in a resource
            return $this->_customerService->storeCustomer($request);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Updates the specified Customer in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @param string $id // Parameter representing the Customer ID.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the updated Customer resource.
     */
    public function update(Request $request, string $id)
    {
        try{
            // Update the specific Customer and return the updated instance and return it wrapped in a resource
            return $this->_customerService->updateCustomer($request, $id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Removes the specified Customer from the database.
     * 
     * @param string $id // Parameter representing the Customer ID.
     * @return CustomerResource // Return type specifying the Customer resource after removal.
     */
    public function destroy(string $id)
    {
        try{
            // Calls the destroyCustomer method in the service layer with the ID and returns the response
            return $this->_customerService->destroyCustomer($id);
        }
        catch(\Exception $e){
            // Propagate exception if any issue occurs
            throw($e);
        }
    }
}
