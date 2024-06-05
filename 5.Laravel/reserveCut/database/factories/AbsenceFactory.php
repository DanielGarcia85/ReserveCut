<?php

// Declares the namespace for database factories to organize factory classes
namespace Database\Factories;

// Imports the base Factory class from Laravel's Eloquent factory system
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * Extends the Laravel Factory class specifically for the Absence model to generate fake data.
 */
class AbsenceFactory extends Factory
{
    /**
     * Define the model's default state.
     * Returns the default set of attributes for the Absence model.
     *
     * @return array<string, mixed> // Returns an array with string keys and mixed values.
     */
    public function definition(): array
    {
        // Generates a start date/time between now and the next year
        $startDate = $this->faker->dateTimeBetween('now', '+1 year');
        // Generates an end date/time based on the start date/time within the next year
        $endDate = $this->faker->dateTimeBetween($startDate, '+1 year');
        
        // Returns an array of attributes for creating an Absence record
        return [
            'date_begin' => $startDate, // Generate a fake random date/time as the start date
            'date_end' => $endDate // Generate a fake random date/time as the end date
        ];
    }
}
