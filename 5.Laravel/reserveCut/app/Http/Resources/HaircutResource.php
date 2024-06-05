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
class HaircutResource extends JsonResource
{
    /**
     * Transform the resource into an array.
     * 
     * @param \Illuminate\Http\Request $request // The incoming request instance.
     * @return array<string, mixed> // Specifies the return type of the method, an array representing the Haircut resource.
     */
    public function toArray(Request $request): array {
        // Checks if the underlying resource is not null
        if ($this->resource) {
            // Returns an array representing the Haircut instance
            return [
                // Returns the Haircut's ID
                'id' => $this->id,
                // Returns the Haircut's name
                'name' => $this->name,
                // Returns the description of the Haircut
                'description' => $this->description,
                // Indicates if the Haircut is long or short
                'long_short' => $this->long_short,
                // Returns the expected duration for the Haircut
                'cutting_time' => $this->cutting_time,
                // Returns the price of the Haircut
                'price' => $this->price,
                // Returns the path to the Haircut's photo
                'photo_path' => $this->when($this->photo_path, $this->photo_path)
            ];
        }
        // Returns an informative response when the resource is null
        return [
            'message' => 'Resource not available', // Provide a general error message
            'status' => 'error'
        ];
    }
}
