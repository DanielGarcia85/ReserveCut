<?php

// Defines the namespace for seeders to organize the seeder classes
namespace Database\Seeders;

// Import the User model for user management
use App\Models\User;
// Import the Stylist model for stylist management         
use App\Models\Stylist;
// Import the Absence model for managing stylist absences
use App\Models\Absence;
// Import the Haircut model for managing types of haircuts           
use App\Models\Haircut;
// Import the Customer model for customer management        
use App\Models\Customer;
// Import the Reservation model for managing service reservations       
use App\Models\Reservation;
// Import Laravel's Seeder base class for database seeding    
use Illuminate\Database\Seeder;
// Import the Role model from Spatie's permission package
use Spatie\Permission\Models\Role;
// Import the Permission model from Spatie's permission package      
use Spatie\Permission\Models\Permission;


/**
 * Extends the base Seeder class provided by Laravel, to define a new seeder
 */
class DatabaseSeeder extends Seeder
{
    /**
     * Seed the application's database.
     * Populates the database with initial data for application testing or initial deployment
     */
    public function run(): void
    {
        // Creates 10 Stylist records using the Stylist factory
        $stylists = Stylist::factory()->count(3)->create();

        // Creates 10 Absence records using the Absence factory
        $absences = Absence::factory()->count(10)->make()
            ->each(function($absence) use ($stylists){
                $absence->stylist_id=$stylists->random()->id;
                // Saves the Absence record to the database
                $absence->save();
            });
        
        // Creates 10 Haircut records using the Haircut factory
        $haircuts  = Haircut::factory()->count(10)->make()
            ->each(function($haircut) use ($stylists){
                $haircut->save();
                // Attaches a random Stylist to each Haircut through a many-to-many relationship
                $haircut->stylists()->attach($stylists->random());
            });

        // Creates 10 Customer records using the Customer factory
        $customers = Customer::factory()->count(50)->make()
            ->each(function($customer) use ($haircuts){
                $customer->haircut_id = $haircuts->random()->id;
                // Saves the Customer record to the database
                $customer->save();
            });

        // Creates 1000 Reservation records using the Reservation factory
        $reservations = Reservation::factory()->count(500)->make()
            ->each(function($reservation) use ($customers, $stylists){
                $reservation->customer_id = $customers->random()->id;
                $reservation->stylist_id = $stylists->random()->id;
                // Saves the Reservation record to the database
                $reservation->save(); 
            });

        // Create my default user and assign the 'admin' role
        $adminUser = User::factory()->create([
            'name' => 'Admin',
            'firstname' => 'Admin',
            'username' => 'a',
            'role' => 'admin',
            'password' => 'a',
        ]);
        $adminUser->syncRoles('admin');

        $normalUser = User::factory()->create([
            'name' => 'User',
            'firstname' => 'User',
            'username' => 'u',
            'role' => 'user',
            'password' => 'u',
        ]);
        $normalUser->syncRoles('user');
    }
}