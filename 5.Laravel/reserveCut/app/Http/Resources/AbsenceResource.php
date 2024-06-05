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
class AbsenceResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     * 
     * @param \Illuminate\Http\Request $request // The incoming request instance.
     * @return array<string, mixed> // Specifies the return type of the method, an array representing the Absence resource.
     */
    public function toArray(Request $request): array {
        // Checks if the underlying resource is not null
        if ($this->resource) {
            // Returns an array representing the Absence instance
            return [
                // Returns the Absence's ID
                'id' => $this->id,
                // Returns the associated Stylist's details
                'stylist' => $this->whenLoaded('stylist', $this->stylist),
                // Returns the start date of the Absence
                'date_begin' => $this->date_begin,
                // Returns the end date of the Absence
                'date_end' => $this->date_end
            ];
        }

        // Returns an informative response when the resource is null
        return [
            'message' => 'Resource not available', // Provide a general error message
            'status' => 'error'
        ];
    }
}
