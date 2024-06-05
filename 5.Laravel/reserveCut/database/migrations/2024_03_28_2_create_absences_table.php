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
     * Creates the 'absences' table with necessary fields.
     */
    public function up(): void
    {
        // Creates the 'absences' table with columns
        Schema::create('absences', function (Blueprint $table) {
            $table->id(); // Primary key column as an auto-incrementing integer
            $table->unsignedBigInteger('stylist_id')->index(); // Foreign key column linked to 'stylists' table
            $table->foreign('stylist_id')->references('id')->on('stylists')->onDelete('restrict')->onUpdate('restrict'); // Foreign key constraint referencing 'stylists' table, restrict on delete/update
            $table->date('date_begin'); // Column for the start date of an absence
            $table->date('date_end'); // Column for the end date of an absence
            $table->timestamps(); // Timestamps columns for created_at and updated_at
        });

    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down(): void
    {
        // Drops the 'absences' table
        Schema::dropIfExists('absences');
    }
};
