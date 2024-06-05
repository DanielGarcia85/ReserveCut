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
     * Creates the 'customers' table with necessary fields.
     */
    public function up(): void
    {
        // Creates the 'customers' table with columns
        Schema::create('customers', function (Blueprint $table) {
            $table->id(); // Primary key column as an auto-incrementing integer
            $table->string('name', 64); // Name column with a maximum length of 64 characters
            $table->string('firstname', 64); // Firstname column with a maximum length of 64 characters
            $table->string('address', 128)->nullable(); // Optional address column, nullable
            $table->bigInteger('postcode')->nullable(); // Optional postcode column, nullable
            $table->string('city', 64)->nullable(); // Optional city column, nullable
            $table->string('phone', 64); // Phone column with a maximum length of 64 characters
            $table->string('email', 64)->nullable(); // Optional email column, nullable
            $table->date('date_birth')->nullable(); // Optional date of birth column, nullable
            $table->string('photo_path', 255)->nullable(); // Optional photo column, nullable
            $table->unsignedBigInteger('haircut_id')->index()->nullable(); // Optional foreign key column linked to 'haircuts' table, nullable
            $table->foreign('haircut_id')->references('id')->on('haircuts')->onDelete('restrict')->onUpdate('restrict'); // Foreign key constraint referencing 'haircuts' table, restrict on delete/update
            $table->string('pref_contact', 64)->nullable(); // Optional preferred contact method column, nullable
            $table->timestamps(); // Timestamps columns for created_at and updated_at
        });

    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down(): void
    {
        // Drops the 'customers' table
        Schema::dropIfExists('customers');
    }
};
