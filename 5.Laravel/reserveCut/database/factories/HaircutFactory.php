<?php

// Declares the namespace for database factories to organize factory classes
namespace Database\Factories;

// Imports the base Factory class from Laravel's Eloquent factory system
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * Extends the Laravel Factory class specifically for the Haircut model to generate fake data.
 */
class HaircutFactory extends Factory
{
    /**
     * Define the model's default state.
     * Returns the default set of attributes for the Haircut model.
     *
     * @return array<string, mixed> // Returns an array with string keys and mixed values.
     */
    public function definition(): array
    {
        // Returns an array of attributes for creating a Haircut record
        return [
            'name' => $this->faker->unique()->word, // Generate a fake unique word used as a random haircut name
            'description' => $this->faker->sentence, // Generate a fake random sentence to describe the haircut
            'long_short' => $this->faker->boolean, // Generate a fake boolean value to determine if the haircut is long or short
            'cutting_time' => $this->faker->numberBetween(15, 120), // Generate a fake random number between 15 and 120 to simulate the time taken for a haircut
            'price' => $this->faker->randomFloat(2, 10, 100), // Generate a fake random floating number to represent the price of the haircut
            'photo_path' => $this->faker->image // Generate a fake randomly generated image path for the haircut
        ];
    }
}
