<?php

// Imports the Request class to handle HTTP requests within the routes
use Illuminate\Http\Request;
// Imports the Route facade to define routes for the application
use Illuminate\Support\Facades\Route;
// Imports the UserController to manage API requests related to User
use App\Http\Controllers\Api\UserController;
// Imports the StylistController to manage API requests related to Stylist
use App\Http\Controllers\Api\StylistController;
// Imports the AbsenceController to manage API requests related to Absence
use App\Http\Controllers\Api\AbsenceController;
// Imports the HaircutController to manage API requests related to Haircut
use App\Http\Controllers\Api\HaircutController;

// Imports the CustomerController to manage API requests related to Customer
use App\Http\Controllers\Api\CustomerController;
// Imports the ReservationController to manage API requests related to Reservation
use App\Http\Controllers\Api\ReservationController;
// Import the AuthController to handle authentication-related actions like login and registration
use App\Http\Controllers\AuthController;

// Defines a route for user login that maps to the 'login' method in the AuthController
Route::post('/login', [AuthController::class, 'login']);

// Define the group routes that require user authentication via Sanctum
Route::middleware('auth:sanctum')->group(function () {
    
    // Routes for managing Users with appropriate permissions
    Route::group(['middleware' => ['can:manageUsers']], function () {
        Route::get('users', [UserController::class, 'index']);
        Route::get('users/{id}', [UserController::class, 'show']);
        Route::post('users', [UserController::class, 'store']);
        Route::patch('users/{id}', [UserController::class, 'update']);
        Route::delete('users/{id}', [UserController::class, 'destroy']);
    });

    // Routes for managing Stylists with appropriate permissions
    Route::group(['middleware' => ['can:viewStylists']], function () {
        Route::get('stylists', [StylistController::class, 'index']);
        Route::get('stylists/{id}', [StylistController::class, 'show']);
    });
    Route::group(['middleware' => ['can:manageStylists']], function () {
        Route::post('stylists', [StylistController::class, 'store']);
        Route::patch('stylists/{id}', [StylistController::class, 'update']);
        Route::delete('stylists/{id}', [StylistController::class, 'destroy']);
    });
    // Routes for managing Absences with appropriate permissions
    Route::group(['middleware' => ['can:viewAbsences']], function () {
        Route::get('absences', [AbsenceController::class, 'index']);
        Route::get('absences/{id}', [AbsenceController::class, 'show']);
    });
    Route::group(['middleware' => ['can:manageAbsences']], function () {
        Route::post('absences', [AbsenceController::class, 'store']);
        Route::patch('absences/{id}', [AbsenceController::class, 'update']);
        Route::delete('absences/{id}', [AbsenceController::class, 'destroy']);
    });
    // Routes for managing Haircuts with appropriate permissions
    Route::group(['middleware' => ['can:viewHaircuts']], function () {
        Route::get('haircuts', [HaircutController::class, 'index']);
        Route::get('haircuts/{id}', [HaircutController::class, 'show']);
    });
    Route::group(['middleware' => ['can:manageHaircuts']], function () {
        Route::post('haircuts', [HaircutController::class, 'store']);
        Route::patch('haircuts/{id}', [HaircutController::class, 'update']);
        Route::delete('haircuts/{id}', [HaircutController::class, 'destroy']);
    });
    // Routes for managing Customers with appropriate permissions
    Route::group(['middleware' => ['can:viewCustomers']], function () {
        Route::get('customers', [CustomerController::class, 'index']);
        Route::get('customers/{id}', [CustomerController::class, 'show']);
    });
    Route::group(['middleware' => ['can:manageCustomers']], function () {
        Route::post('customers', [CustomerController::class, 'store']);
        Route::patch('customers/{id}', [CustomerController::class, 'update']);
        Route::delete('customers/{id}', [CustomerController::class, 'destroy']);
    });
    // Routes for managing Reservations with appropriate permissions
    Route::group(['middleware' => ['can:viewReservations']], function () {
        Route::get('reservations', [ReservationController::class, 'index']);
        Route::get('reservations/{id}', [ReservationController::class, 'show']);
    });
    Route::group(['middleware' => ['can:manageReservations']], function () {
        Route::post('reservations', [ReservationController::class, 'store']);
        Route::patch('reservations/{id}', [ReservationController::class, 'update']);
        Route::delete('reservations/{id}', [ReservationController::class, 'destroy']);
    });
});