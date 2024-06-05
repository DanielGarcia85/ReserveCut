<?php

// Specify the namespace for HTTP service classes to organize service-related classes
namespace App\Http\Services;

// Import the User model to interact with User's data in the database
use App\Models\User;
// Import the Request class to handle HTTP requests in service methods
use Illuminate\Http\Request;
// Import the Validator facade to validate incoming data against specific rules
use Illuminate\Support\Facades\Validator;
// Import the Hash facade to handle password hashing
use Illuminate\Support\Facades\Hash;
// Import the ModelNotFoundException for handling cases where a model instance isn't found in the database
use Illuminate\Database\Eloquent\ModelNotFoundException;
// Imports the UserResource class, which provides a means to format and return User data structures for API responses
use App\Http\Resources\UserResource;
// Imports the ApiResponse helper class to standardize and simplify the creation of JSON responses throughout the application
use App\Http\Middleware\ApiResponse;
// Import Role from Spatie package
use Spatie\Permission\Models\Role;
// Import the RoleDoesNotExist exception class from Spatie's Permission package to handle cases where a specified role does not exist
use Spatie\Permission\Exceptions\RoleDoesNotExist;
// Import the Str helper for string manipulation
use Illuminate\Support\Str;

/**
 * Define the service class for handling User operations
 */
class UserService
{
    /**
    * Retrieves and returns all Users from the database.
    * This method ensures that the returned collection of User models is formatted using ApiResponse::format with UsersResource to ensure consistency and accuracy of the API response.
    *
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing a collection of User models. The data is formatted for API consistency and accuracy.
    * If there's an error during the fetching process, it returns a JSON response with a code 500 status.
    */
    public function indexUser()
    {
        try {
            // Return all Users records from the database
            $users = User::all();
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including all the retrieved Users details, formatted using ApiResponse::format
            //return ApiResponse::format('users', UserResource::collection($users), 200);
            return response()->json(UserResource::collection($users), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Retrieves and returns a single User from the database by the User's ID.
    * This method ensures that the returned User is formatted using ApiResponse::format with UserResource to ensure consistency and accuracy of the API response.
    *
    * @param string $id The ID of the User to retrieve.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the specific User model. If successful, it returns a JSON response with a code 200 status.
    * If the User is not found, it returns a JSON response with a code 404 status.
    * For any other errors during the retrieval process, it returns a JSON response with a code 500 status.
    */
    public function showUser(string $id)
    {
        try {
            // Attempt to find the User by its ID. If not found, a ModelNotFoundException is thrown
            $user = User::findOrFail($id);
            // Return a JSON response with a code 200 status, indicating a successful retrieval, and including the retrieved USer details, formatted using ApiResponse::format
            //return ApiResponse::format('user', new UserResource($user), 200);
            return response()->json(new UserResource($user), 200);
        } catch (ModelNotFoundException $e) {
            // If the User is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (User) does not exist
            return response()->json(['message' => 'User not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and stores a new User record based on the provided request data.
    * This method ensures data validation and handles errors or exceptions by returning appropriate JSON responses.
    * 
    * @param \Illuminate\Http\Request $request Request object containing the data for creating an User.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the newly created User model. If the creation is successful, formatted using ApiResponse::format with StylistResource to ensure consistency and accuracy of the API response.
    * If the validation is successful, it returns a JSON response with a code 200 status, indicating successful insertion.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * For any other errors during the saving process, it returns a JSON response with a code 500 status.
    */
    public function storeUser(Request $request)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'name' => 'required|max:64', // 'name' is required and must not exceed 64 characters
                'firstname' => 'required|max:64', // 'firstname' is required and must not exceed 64 characters
                'username' => 'required|unique:users,username|max:64', // 'username' is required, must be unique in the 'users' table, and must not exceed 64 characters
                'password' => 'required|min:8|max:20', // 'password' is required, must be at least 8 characters, and must not exceed 20 characters
                'role' => 'required|in:admin,user', // 'role' is required and must be either 'admin' or 'user'
            ]);
            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Create a new User instance and fill it with request data
            $user = new User();
            $user->name = $request->input('name');
            $user->firstname = $request->input('firstname');
            $user->username = $request->input('username');
            $user->password = Hash::make($request->input('password'));
            $user->role = $request->input('role');
            $user->remember_token = Str::random(10);
            // Assign role to user
            try {
                $role = Role::findByName($request->input('role'), 'web');
                $user->assignRole($role);
            } catch (RoleDoesNotExist $e) {
                // If the role does not exist, return an error response
                return response()->json(['message' => "The role does not exist."], 422);
            }
            // Save the User to the database
            $user->save();
            // Return a JSON response with a code 200 status, indicating a successful insertion, and including the inserted User details, formatted using ApiResponse::format
            //return ApiResponse::format('user', new UserResource($user), 200);
            return response()->json(new UserResource($user), 200);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Validates and stores a new User record based on the provided request data.
    * This method ensures data validation and handles errors or exceptions by returning appropriate JSON responses.
    * 
    * @param \Illuminate\Http\Request $request Request object containing the data for creating a User.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response containing the newly created User model. If the creation is successful, formatted using ApiResponse::format with UserResource to ensure consistency and accuracy of the API response.
    * If the validation is successful, it returns a JSON response with a code 200 status, indicating successful insertion.
    * If validation fails, it returns a JSON response with a code 422 status, detailing the validation errors.
    * For any other errors during the saving process, it returns a JSON response with a code 500 status.
    */
    public function updateUser(Request $request, string $id)
    {
        try {
            // Validate the incoming request data
            $validator = Validator::make($request->all(), [
                'name' => 'required|max:64', // 'name' 
                'firstname' => 'required|max:64', // 'firstname' is required and must not exceed 64 characters
                'username' => 'required|max:64|unique:users,username,'.$id, // 'username' is required, must be unique in the 'users' table, and must not exceed 64 characters (but can be the same as old one)
                'password' => 'nullable|min:8|max:20', // 'password' is required, must be at least 8 characters, and must not exceed 20 characters
                'role' => 'required|in:admin,user', // 'role' is required and must be either 'admin' or 'user'
            ]);

            // Check if validation fails
            if ($validator->fails()) {
                // If the validation fails, return a JSON response with a code 422 status, detailing the validation errors encountered
                return response()->json(['errors' => $validator->errors()], 422);
            }
            // Attempt to find the User by its ID. If not found, a ModelNotFoundException is thrown
            $user = User::findOrFail($id);
            // Update the User with request data
            $user->name = $request->input('name');
            $user->firstname = $request->input('firstname');
            $user->username = $request->input('username');
            if ($request->filled('password')) {
                $user->password = Hash::make($request->input('password'));
            }
            $user->role = $request->input('role');
            // Re-assign role to user
            try {
                $role = Role::findByName($request->input('role'), 'web');
                $user->roles()->detach();
                $user->assignRole($role);
            } catch (RoleDoesNotExist $e) {
                // If the role does not exist, return an error response
                throw new HttpException(422, json_encode(['role' => ['The role does not exist.']]));
            }
            // Save the updated User to the database
            $user->save();
            // Return a JSON response with a code 200 status, indicating a successful update, and including the updated User details, formatted using ApiResponse::format
            //return ApiResponse::format('user', new UserResource($user), 200);
            return response()->json(new UserResource($user), 200);
        } catch (ModelNotFoundException $e) {
            // If the User is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (User) does not exist
            return response()->json(['message' => 'User not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }

    /**
    * Deletes a User record by ID from the database and returns a JSON response
    *
    * @param string $id The ID of the User to be deleted.
    * @return \Illuminate\Http\JsonResponse Returns a JSON response with a code 200 status, indicating successful deletion
    * @throws \Symfony\Component\HttpKernel\Exception\HttpException Throws an HTTP exception with a 404 status code if the User is not found
    * @throws \Symfony\Component\HttpKernel\Exception\HttpException Throws an HTTP exception with a 500 status code for any other errors during the deletion process
    */
    public function destroyUser(string $id)
    {
        try {
            // Get the currently authenticated user
            $currentUser = auth()->user();
            // Check if the current user is trying to delete themselves
            if ($currentUser->id == $id) {
                return response()->json(['message' => 'You cannot delete your own account'], 403);
            }
            // Attempt to find the User by its ID. If not found, a ModelNotFoundException is thrown
            $user = User::findOrFail($id);
            // Delete the found User from the database
            $user->delete();
            // Return a JSON response with a code 200 status, indicating successful deletion
            return response()->json(['message' => 'User deleted successfully', 'user_id' => $user->id], 200);
        } catch (ModelNotFoundException $e) {
            // If the User is not found in the database, return a JSON response with a code 404 status, indicating that the requested resource (User) does not exist
            return response()->json(['message' => 'User not found'], 404);
        } catch (\Exception $e) {
            // Handle general errors by returning a JSON response with a code 500 status, with a detailed error message
            return response()->json(['message' => "An error occurred: " . $e->getMessage()], 500);
        }
    }
    
}
