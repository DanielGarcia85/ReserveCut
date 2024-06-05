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
     * Creates the 'personal_access_tokens' table for storing API token details.
     */
    public function up(): void
    {
        // Creates the 'personal_access_tokens' table with necessary columns and constraints
        Schema::create('personal_access_tokens', function (Blueprint $table) {
            $table->id(); // Primary key column as an auto-incrementing integer
            $table->morphs('tokenable'); // Polymorphic relation columns for tokenable_type and tokenable_id
            $table->string('name'); // Name of the token
            $table->string('token', 64)->unique(); // Token string itself, ensured unique
            $table->text('abilities')->nullable(); // JSON text field to store token abilities, nullable
            $table->timestamp('last_used_at')->nullable(); // Timestamp of the last use, nullable
            $table->timestamp('expires_at')->nullable(); // Expiry date and time of the token, nullable
            $table->timestamps(); // Timestamps columns for created_at and updated_at
        });
    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down(): void
    {
        // Drops the 'personal_access_tokens' table
        Schema::dropIfExists('personal_access_tokens');
    }
};
