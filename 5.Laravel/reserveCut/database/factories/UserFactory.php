<?php

// Declare the namespace for the Factory related to User models to group related Factory classes
namespace Database\Factories;

// Import the base Factory class to create new models
use Illuminate\Database\Eloquent\Factories\Factory;
// Import the Hash facade to handle password hashing
use Illuminate\Support\Facades\Hash;
// Import the Str helper for string manipulation
use Illuminate\Support\Str;

/**
 * Extends the Laravel Factory class specifically for the User model to generate fake data.
 */
class UserFactory extends Factory
{
    /**
     * The current password being used by the factory, stored statically to avoid rehashing.
     */
    protected static ?string $password;

    /**
     * Define the model's default state.
     * Provides a default set of attribute values for the User model.
     *
     * @return array<string, mixed> // Returns an array with string keys and mixed values.
     */
    public function definition(): array
    {
        // Define the possible values for role
        $roleOptions = ['admin', 'user'];

        // Returns an array of attributes for creating a User record
        return [
            'name' => fake()->name(), // Generates a fake name for the 'name' attribute
            'firstname' => fake()->firstname(), // Generates a fake firstname for the 'firstname' attribute
            'username' => fake()->unique()->userName(), // Generates a unique fake username for the 'username' attribute
            'password' => static::$password ??= Hash::make('123456789'), // Generates a hashed password '1234' for the 'password' attribute
            'role' => fake()->randomElement($roleOptions), // Randomly selects either 'admin' or 'user' for the 'role' attribute
            'remember_token' => Str::random(10), // Generates a random string for the 'remember_token' attribute
        ];
    }

}
