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
class StylistResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     * 
     * @param \Illuminate\Http\Request $request // The incoming request instance.
     * @return array<string, mixed> // Specifies the return type of the method, an array representing the Stylist resource.
     */
    public function toArray(Request $request): array {
        // Checks if the underlying resource is not null
        if ($this->resource) {
            // Returns an array representing the Stylist instance
            return [
                // Returns the Stylist's ID
                'id' => $this->id,
                // Returns the Stylist's name
                'name' => $this->name,
                // Returns the Stylist's firstname
                'firstname' => $this->firstname,
                // Returns the path to the Stylist's photo
                'photo_path' => $this->when($this->photo_path, $this->photo_path),
                // Include Haircuts related to the Stylist
                'haircuts' => HaircutResource::collection($this->whenLoaded('haircuts')),
                // Include Reservations related to the Stylist
                'reservations' => ReservationResource::collection($this->whenLoaded('reservations')),
                // Include Absences related to the Stylist
                'absences' => AbsenceResource::collection($this->whenLoaded('absences'))
            ];
        }

        // Returns an informative response when the resource is null
        return [
            'message' => 'Resource not available', // Provide a general error message
            'status' => 'error'
        ];
    }
}
