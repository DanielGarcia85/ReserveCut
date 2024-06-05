<?php

// Declares the namespace for the resource
namespace App\Http\Resources;

// Imports the Request class for usage within this file
use Illuminate\Http\Request;
// Imports the JsonResource class to create an API resource
use Illuminate\Http\Resources\Json\JsonResource;

/**
 * Defines a resource class that extends JsonResource.
 */
class UserResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     * 
     * @param \Illuminate\Http\Request $request // The incoming request instance.
     * @return array<string, mixed> // Specifies the return type of the method, an array representing the User resource.
     */
    public function toArray(Request $request): array {
        // Checks if the underlying resource is not null
        if ($this->resource) {
            // Returns an array representing the User instance
            return [
                'id' => $this->id, // Returns the User's ID
                'name' => $this->name, // Returns the User's name
                'firstname' => $this->firstname, // Returns the User's firstname
                'username' => $this->username, // Returns the User's username
                'role' => $this->role, // Returns the User's role
            ];
        }

        // Returns an informative response when the resource is null
        return [
            'message' => 'Resource not available', // Provide a general error message
            'status' => 'error'
        ];
    }
}
