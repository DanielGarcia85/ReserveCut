<?php

// Import the Application class for initializing and configuring the Laravel application
use Illuminate\Foundation\Application;
// Import the Exceptions configuration class for handling application exceptions
use Illuminate\Foundation\Configuration\Exceptions;
// Import the Middleware configuration class for setting up middleware layers
use Illuminate\Foundation\Configuration\Middleware;
// Import the custom middleware to enforce JSON responses globally
use App\Http\Middleware\ForceJsonResponse;


/**
 * Configure and initialize the Laravel application instance
 * This script sets up routing, middleware, and exception handling configurations
 */
return Application::configure(basePath: dirname(__DIR__))
    // Set the base path for the application
    ->withRouting(
        web: __DIR__.'/../routes/web.php',
        api: __DIR__.'/../routes/api.php',
        commands: __DIR__.'/../routes/console.php',
        health: '/up',
    )
    // Register middleware that should be applied to all requests
    ->withMiddleware(function (Middleware $middleware) {
        $middleware->append(ForceJsonResponse::class);
    })
    // Configure exception handling
    ->withExceptions(function (Exceptions $exceptions) {
    
    })->create();// Finalize and create the application instance
