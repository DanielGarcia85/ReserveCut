<?php

// Declares the namespace for database factories to organize factory classes
namespace Database\Factories;

// Imports the base Factory class from Laravel's Eloquent factory system
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * Extends the Laravel Factory class specifically for the Reservation model to generate fake data.
 */
class ReservationFactory extends Factory
{
    /**
     * Define the model's default state.
     * Returns the default set of attributes for the Reservation model.
     *
     * @return array<string, mixed> // Returns an array with string keys and mixed values.
     */
    public function definition(): array
    {
    // Generate a fake random date between now and the next year
    $startDate = $this->faker->dateTimeBetween('now', '+3 month');
    // Generate a random hour between 8 and 17
    $hour = $this->faker->numberBetween(8, 17);
    // Generate a random minute of 00 or 30
    $minute = $this->faker->randomElement([0, 30]);
    // Set the date_begin with the generated hour and minute
    $dateBegin = (clone $startDate)->setTime($hour, $minute);
    // Calculate the end date by adding the random interval to the start date
    $dateEnd = (clone $dateBegin)->modify("+30 minutes");
        // Returns an array of attributes for creating a Reservation record
        return [
            'date_begin' => $dateBegin, // Generate a fake random date/time between now and the next year as the start date
            'date_end' => $dateEnd, // Generate a end date 30 minutes after the start date 
            'comments' => $this->faker->sentence, // Generate a fake random sentence as comments for the reservation
            'beard_y_n' => $this->faker->boolean, // Generate a fake boolean value to indicate if a beard service is required
            'shampoo_y_n' => $this->faker->boolean, // Generate a fake boolean value to indicate if a shampoo service is required
        ];
    }
}
