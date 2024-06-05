<?php

// Specify the namespace for the Middleware to organize middleware classes
namespace App\Http\Middleware;

// Import the Closure class to define anonymous functions or closures, often used as callbacks
use Closure;
// Import the Request class from Illuminate\Http to handle HTTP requests within middleware
use Illuminate\Http\Request;
// Import the Response class from Symfony\Component\HttpFoundation to handle HTTP responses
use Symfony\Component\HttpFoundation\Response;

/**
 * Middleware to enforce JSON format for all responses
 * It modifies the 'Accept' header to 'application/json' on incoming requests
 */
class ForceJSONResponse
{
    /**
    * Intercept an incoming request to enforce JSON responses
    * Sets the 'Accept' header to 'application/json' to standardize all API responses to JSON format
    *
    * @param Request $request The incoming HTTP request
    * @param Closure $next The next middleware or controller to process the request
    * @return Response The response after processing by subsequent middleware or the controller
    */
    public function handle(Request $request, Closure $next): Response
    {   
        // Set the 'Accept' header of the request to 'application/json'
        $request->headers->set('Accept', 'application/json');
        // Pass the request to the next middleware
        return $next($request);
    }
}
