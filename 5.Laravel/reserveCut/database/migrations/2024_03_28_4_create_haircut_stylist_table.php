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
     * Creates the 'haircut_stylist' pivot table to manage the many-to-many relationship between haircuts and Stylists.
     */
    public function up(): void
    {
        // Creates the 'haircut_stylist' table with foreign keys pointing to 'stylists' and 'haircuts'
        Schema::create('haircut_stylist', function (Blueprint $table) {
            $table->unsignedBigInteger('stylist_id')->index(); // Column for Stylist ID with an index for faster lookups
            $table->foreign('stylist_id')->references('id')->on('stylists')->onDelete('restrict')->onUpdate('restrict'); // Foreign key constraint referencing 'stylists' table, restrict on delete/update
            $table->unsignedBigInteger('haircut_id')->index(); // Column for haircut ID with an index for faster lookups
            $table->foreign('haircut_id')->references('id')->on('haircuts')->onDelete('restrict')->onUpdate('restrict'); // Foreign key constraint referencing 'haircuts' table, restrict on delete/update
        });

    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down(): void
    {
        // Drops the 'haircut_stylist' table
        Schema::dropIfExists('haircut_stylist');
    }
};
