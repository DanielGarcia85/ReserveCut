<?php

// Specify the namespace to organize the class, making it part of the App\Http\Helpers directory structure
namespace App\Http\Middleware;

// Import the JsonResponse class from the Laravel framework to handle HTTP responses
use Illuminate\Http\JsonResponse;

// Declare a class named ApiResponse
class ApiResponse
{
    // Define a static function named 'format' that takes a key, data, and a status code, returning a JsonResponse
    public static function format($key, $data, $statusCode): JsonResponse
    {
        // Return a JsonResponse containing the data under the specified key with the provided status code
        return response()->json([$key => $data], $statusCode);
    }
}
