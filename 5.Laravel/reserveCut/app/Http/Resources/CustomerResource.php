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
class CustomerResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     * 
     * @param \Illuminate\Http\Request $request // The incoming request instance.
     * @return array<string, mixed> // Specifies the return type of the method, an array representing the Customer resource.
     */
    public function toArray(Request $request): array {
        // Checks if the underlying resource is not null
        if ($this->resource) {
            // Returns an array representing the Customer instance
            return [
                // Returns the Customer's ID
                'id' => $this->id,
                // Returns the Customer's name
                'name' => $this->name,
                // Returns the Customer's firstname
                'firstname' => $this->firstname,
                // Returns the Customer's address
                'address' => $this->address,
                // Returns the Customer's postcode
                'postcode' => $this->postcode,
                // Returns the city of the Customer
                'city' => $this->city,
                // Returns the Customer's phone number
                'phone' => $this->phone,
                // Returns the Customer's email address
                'email' => $this->email,
                // Returns the date of birth of the Customer
                'date_birth' => $this->date_birth,
                // Returns the path to the Customer's photo
                'photo_path' => $this->when($this->photo_path, $this->photo_path),
                // Returns the preferred contact method of the Customer
                'pref_contact' => $this->pref_contact,
                // Returns the associated Haircut's details
                'haircut' => $this->whenLoaded('haircut', $this->haircut),
                // Returns the associated Reservations
                'reservations' => ReservationResource::collection($this->whenLoaded('reservations'))
            ];
        }

        // Returns an informative response when the resource is null
        return [
            'message' => 'Resource not available', // Provide a general error message
            'status' => 'error'
        ];
    }
}
