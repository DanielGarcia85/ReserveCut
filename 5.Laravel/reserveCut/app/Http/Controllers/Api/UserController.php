<?php

// Specify the namespace for API controllers to structure and organize controller classes
namespace App\Http\Controllers\Api;

// Extend from the base Controller class to inherit base functionalities
use App\Http\Controllers\Controller;
// Import the Request class to handle HTTP requests in the controller methods
use Illuminate\Http\Request;
// Import the UserService to handle the business logic related to User
use App\Http\Services\UserService;
// Import the UserResource to transform and format the User model data for API responses
use App\Http\Resources\UserResource;

/**
 * Controller class for handling User-related API requests
 */
class UserController
{
    /**
     * Injects UserService for handling business logic.
     */
    public function __construct(private UserService $_userService){}

    /**
     * Retrieves all Users and returns them as a collection of resources.
     * 
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing a collection of User resources.
     */
    public function index()
    {
        try {
            // Retrieve all Users using the UserService and return it wrapped in a resource
            return $this->_userService->indexUser();
        } catch (\Exception $e) {
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Displays a specific User.
     * 
     * @param string $id // Parameter representing the User ID.
     * @return \Illuminate\Http\JsonResponse Return type specifying a JSON response containing a single User resource.
     */
    public function show(string $id)
    {
        try {
            // Retrieve the specific User using its ID and return it wrapped in a resource
            return $this->_userService->showUser($id);
        } catch (\Exception $e) {
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Stores a newly created User in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the created User resource.
     */
    public function store(Request $request)
    {
        try {
            // Store the new User and return the created instance and return it wrapped in a resource
            return $this->_userService->storeUser($request);
        } catch (\Exception $e) {
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Updates the specified User in the database.
     * 
     * @param \Illuminate\Http\Request $request // Parameter representing the incoming HTTP request.
     * @param string $id // Parameter representing the User ID.
     * @return \Illuminate\Http\JsonResponse // Return type specifying a JSON response containing the updated User resource.
     */
    public function update(Request $request, string $id)
    {
        try {
            // Update the specific User and return the updated instance and return it wrapped in a resource
            return$this->_userService->updateUser($request, $id);
        } catch (\Exception $e) {
            // Propagate exception if any issue occurs
            throw($e);
        }
    }

    /**
     * Removes the specified User from the database.
     * 
     * @param string $id // Parameter representing the User ID.
     * @return \Illuminate\Http\JsonResponse // Return type specifying the JSON response after removal.
     */
    public function destroy(string $id)
    {
        try {
            // Calls the destroyUser method in the service layer with the ID and returns the response
            return $this->_userService->destroyUser($id);
        } catch (\Exception $e) {
            // Propagate exception if any issue occurs
            throw($e);
        }
    }
}
