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
     * Run the migrations.
     * Creates the 'haircuts' table with necessary fields.
     */
    public function up(): void
    {
        // Creates the 'haircuts' table with columns
        Schema::create('haircuts', function (Blueprint $table) {
            $table->id(); // Primary key column as an auto-incrementing integer
            $table->string('name', 64)->unique(); // Name column with a maximum length of 64 characters, unique
            $table->string('description', 255)->nullable(); // Optional description column, nullable
            $table->boolean('long_short')->nullable(); // Option boolean column to indicate if the haircut is long or short, nullable
            $table->integer('cutting_time'); // Integer column for the duration of the haircut
            $table->double('price'); // Double column for the price of the haircut
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
        // Drops the 'haircuts' table
        Schema::dropIfExists('haircuts');
    }
};
