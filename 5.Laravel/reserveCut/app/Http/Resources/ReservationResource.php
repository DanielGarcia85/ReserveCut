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
class ReservationResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     * 
     * @param \Illuminate\Http\Request $request // The incoming request instance.
     * @return array<string, mixed> // Specifies the return type of the method, an array representing the Reservation resource.
     */
    public function toArray(Request $request): array {
        // Checks if the underlying resource is not null
        if ($this->resource) {
            // Returns an array representing the Reservation instance
            return [
                // Returns the Reservation's ID
                'id' => $this->id,
                // Returns the associated Customer's details
                'customer' => [
                    'haircut' => [
                        'id' => $this->customer->haircut->id,
                    ], 
                ],
                'customer' => $this->whenLoaded('customer', $this->customer),
                // Returns the associated Stylist's details
                'stylist' => $this->whenLoaded('stylist', $this->stylist),
                // Returns the start date of the Reservation
                'date_begin' => $this->date_begin,
                // Returns the end date of the Reservation
                'date_end' => $this->date_end,
                // Returns any comments related to the Reservation
                'comments' => $this->comments,
                // Returns whether the Reservation includes a beard service
                'beard_y_n' => $this->beard_y_n,
                // Returns whether the Reservation includes a shampoo service
                'shampoo_y_n' => $this->shampoo_y_n
            ];
        }

        // Returns an informative response when the resource is null
        return [
            'message' => 'Resource not available', // Provide a general error message
            'status' => 'error'
        ];
    }
}
