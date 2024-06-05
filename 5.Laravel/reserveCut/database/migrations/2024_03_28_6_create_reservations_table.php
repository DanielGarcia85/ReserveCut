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
     * Creates the 'reservations' table with necessary fields.
     */
    public function up(): void
    {
        // Creates the 'reservations' table with columns for managing reservations
        Schema::create('reservations', function (Blueprint $table) {
            $table->id(); // Primary key column as an auto-incrementing integer
            $table->unsignedBigInteger('customer_id')->index(); // Foreign key column linked to 'customers' table
            $table->foreign('customer_id')->references('id')->on('customers')->onDelete('restrict')->onUpdate('restrict'); // Foreign key constraint referencing 'customers' table, restrict on delete/update
            $table->unsignedBigInteger('stylist_id')->index()->nullable(); // Optional foreign key column for stylists, nullable
            $table->foreign('stylist_id')->references('id')->on('stylists')->onDelete('restrict')->onUpdate('restrict'); // Foreign key constraint referencing 'stylists' table, restrict on delete/update
            $table->dateTime('date_begin'); // Date and time for when the reservation begins
            $table->dateTime('date_end'); // Date and time for when the reservation ends
            $table->string('comments', 255)->nullable(); // Optional comments about the reservation, nullable
            $table->boolean('beard_y_n')->nullable(); // Optional boolean column to indicate if a beard service is needed, nullable
            $table->boolean('shampoo_y_n')->nullable(); // Optional boolean column to indicate if a shampoo service is needed, nullable
            $table->timestamps(); // Timestamps columns for created_at and updated_at
        });

    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down(): void
    {
        // Drops the 'reservations' table
        Schema::dropIfExists('reservations');
    }
};
