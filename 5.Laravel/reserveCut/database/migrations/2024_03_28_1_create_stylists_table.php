<?php

// Imports the Migration base class from Laravel's database migration library
use Illuminate\Database\Migrations\Migration;
// Imports the Blueprint class to define the table structure within the migrations
use Illuminate\Database\Schema\Blueprint;
// Imports the Schema facade to provide a database-agnostic way of manipulating tables
use Illuminate\Support\Facades\Schema;

// Declares a new anonymous class that extends the Laravel Migration base class
return new class extends Migration
{
    /**
     * Run the migrations
     * Creates the 'stylists' table with necessary fields.
     */
    public function up(): void
    {
        // Creates the 'stylists' table with columns
        Schema::create('stylists', function (Blueprint $table) {
            $table->id(); // Primary key column as an auto-incrementing integer
            $table->string('name', 64); // Name column with a maximum length of 64 characters
            $table->string('firstname', 64); // Firstname column with a maximum length of 64 characters
            $table->string('photo_path', 255)->nullable(); // Optional photo column, nullable
            $table->timestamps(); // Timestamps columns for created_at and updated_at
        });

    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down(): void
    {
        // Drops the 'stylists' table
        Schema::dropIfExists('stylists');
    }
};
