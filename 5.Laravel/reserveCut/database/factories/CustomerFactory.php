<?php

// Declares the namespace for database factories to organize factory classes
namespace Database\Factories;

// Imports the base Factory class from Laravel's Eloquent factory system
use Illuminate\Database\Eloquent\Factories\Factory;

/**
 * Extends the Laravel Factory class specifically for the Customer model to generate fake data.
 */
class CustomerFactory extends Factory
{
    /**
     * Define the model's default state.
     * Returns the default set of attributes for the Customer model.
     *
     * @return array<string, mixed> // Returns an array with string keys and mixed values.
     */
    public function definition(): array
    {
        // Define the possible values for preferred contact
        $prefContactOptions = ['phone', 'email', 'mail', 'no contact'];

        // Returns an array of attributes for creating a Customer record
        return [
            'name' => $this->faker->lastName, // Generate a fake last name of the customer
            'firstname' => $this->faker->firstName, // Generate a fake first name of the customer
            'address' => $this->faker->streetAddress, // Generate a fake street address of the customer
            'postcode' => $this->faker->buildingNumber, // Generate a fake postcode of the customer
            'city' => $this->faker->city, // Generate a fake city where the customer resides
            'phone' => $this->faker->e164PhoneNumber, // Generate a fake phone number of the customer in E.164 format
            'email' => $this->faker->email, // Generate a fake email address of the customer
            'date_birth' => $this->faker->date, // Generate a fake date of birth of the customer
            'photo_path' => $this->faker->image, // Generate a fake randomly generated image path for the customer
            'pref_contact' => $this->faker->randomElement($prefContactOptions)  // Generate a fake randomly select one of the preferred contact options
        ];
    }
}
