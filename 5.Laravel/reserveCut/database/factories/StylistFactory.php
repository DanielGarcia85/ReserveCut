<?php

// Declares the namespace for database factories to organize factory classes
namespace Database\Factories;

// Imports the base Factory class from Laravel's Eloquent factory system
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * Extends the Laravel Factory class specifically for the Stylist model to generate fake data.
 */
class StylistFactory extends Factory
{
    /**
     * Define the model's default state.
     * Returns the default set of attributes for the Stylist model.
     *
     * @return array<string, mixed> // Returns an array with string keys and mixed values.
     */
    public function definition(): array
    {
        // Returns an array of attributes for creating a Stylist record
        return [
            'name' => $this->faker->lastName, // Generate a fake last name of the stylist
            'firstname' => $this->faker->firstName, // Generate a fake firstname of the stylist
            'photo_path' => $this->faker->image(null, 640, 480, 'people', true) // Random image URL generated as the photo of the stylist
        ];
    }
}
