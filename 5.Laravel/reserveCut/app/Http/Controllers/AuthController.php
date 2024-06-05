<?php

// Defines the namespace for the controller class
namespace App\Http\Controllers;

// Import the Request class to access HTTP request details
use Illuminate\Http\Request;
// Import the Auth facade for user authentication operations
use Illuminate\Support\Facades\Auth;

// Define AuthController class that extends Laravel's base Controller class
class AuthController
{
    public function login(Request $request)
    {
        // Extract email and password from the request
        $credentials = $request->only('username', 'password');

        // Attempt to authenticate using the provided credentials
        if (Auth::attempt($credentials)) {
            // Retrieve the authenticated user instance
            $user = Auth::user();
            // Generate a new personal access token
            $token = $user->createToken('MyAppToken')->plainTextToken;

            // Return a JSON response with login details
            return response()->json([
                // Message indicating successful login
                'message' => 'Successful login',
                // Include the plaintext token in the response
                'token' => $token,
                // Specifies the type of the token provided
                'token_type' => 'Bearer',
                // Include the user object in the response
                'user' => $user
            ], 200);
        }

        // Return an unauthorized status if authentication fails
        return response()->json(['message' => 'Unauthorized'], 401);
    }
}
