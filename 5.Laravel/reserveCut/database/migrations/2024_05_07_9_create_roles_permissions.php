<?php

// Import the Migration class from Laravel's database migration functionalities to create database changes
use Illuminate\Database\Migrations\Migration;
// Import the Blueprint class, which is responsible for defining the schema of tables within the database
use Illuminate\Database\Schema\Blueprint;
// Import the Schema facade, which provides database schema building support
use Illuminate\Support\Facades\Schema;
// Import the Role model from the Spatie Permission package, which represents a role that can be assigned to users
use Spatie\Permission\Models\Role;
// Import the Permission model from the Spatie Permission package, which represents a permission that can be associated with roles
use Spatie\Permission\Models\Permission;

// Define a new class named CreateRolesPermissions which extends the Migration class provided by Laravel
// This class will be used to handle the creation of roles and permissions within the database
class CreateRolesPermissions extends Migration
{
    /**
     * Run the migrations.
     * This method sets up the initial roles and permissions within the database, assigning capabilities across different aspects of the system.
     *
     * @return void
     */
    public function up()
    {
        // Create a new 'admin' role in the database
        $roleAdmin = Role::create(['name' => 'admin']);
        // Create a new 'user' role in the database
        $roleUser = Role::create(['name' => 'user']);

        //Create permission to manage Users
        $permManageUsers = Permission::create(['name' => 'manageUsers']);
        // Create permission to manage Reservations
        $permManageReservations = Permission::create(['name' => 'manageReservations']);
        // Create permission to view Reservations
        $permViewReservations = Permission::create(['name' => 'viewReservations']);
        // Create permission to manage Customers
        $permManageCustomers = Permission::create(['name' => 'manageCustomers']);
        // Create permission to view Customers
        $permViewCustomers = Permission::create(['name' => 'viewCustomers']);
        // Create permission to manage Stylists
        $permManageStylists = Permission::create(['name' => 'manageStylists']);
        // Create permission to view Stylists
        $permViewStylists = Permission::create(['name' => 'viewStylists']);
        // Create permission to manage Absences
        $permManageAbsences = Permission::create(['name' => 'manageAbsences']);
        // Create permission to view Absences
        $permViewAbsences = Permission::create(['name' => 'viewAbsences']);
        // Create permission to manage Haircuts
        $permManageHaircuts = Permission::create(['name' => 'manageHaircuts']);
        // Create permission to view Haircuts
        $permViewHaircuts = Permission::create(['name' => 'viewHaircuts']);

        // Sync multiple permissions with the 'admin' role, granting full access to management and viewing capabilities across various features
        $roleAdmin->syncPermissions([
            $permManageUsers, $permManageReservations, $permManageCustomers, 
            $permManageStylists, $permManageAbsences, $permManageHaircuts,
            $permViewReservations, $permViewCustomers, $permViewStylists, 
            $permViewAbsences, $permViewHaircuts
        ]);

        // Sync view-only permissions with the 'user' role, limiting access to viewing information without management rights
        $roleUser->syncPermissions([
            $permManageReservations, $permManageCustomers, 
            $permViewReservations, $permViewCustomers, 
            $permViewStylists, $permViewAbsences, $permViewHaircuts
        ]);
    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down()
    {
        // Remove all roles and permissions
        Role::where('name', 'admin')->delete();
        Role::where('name', 'user')->delete();
        Permission::whereIn('name', [
            'manageUsers', 'manageReservations', 'viewReservations', 
            'manageCustomers', 'viewCustomers', 'manageStylists', 
            'viewStylists', 'manageAbsences', 'viewAbsences', 
            'manageHaircuts', 'viewHaircuts'
        ])->delete();
    }
}
