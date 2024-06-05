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
     * Creates the 'users' table, the 'password_reset_tokens' table, and the 'sessions' table with necessary fields.
     */
    public function up(): void
    {
        // Creates the 'users' table with columns
        Schema::create('users', function (Blueprint $table) {
            $table->id(); // Primary key column as an auto-incrementing integer
            $table->string('name', 64); // Name column with a maximum length of 64 characters
            $table->string('firstname', 64); // Firstname column with a maximum length of 64 characters
            $table->string('username', 64)->unique(); // Unique username column with a maximum length of 64 characters
            $table->string('password'); // Password column
            $table->enum('role', ['admin', 'user'])->default('user'); // Enum column for role, defaulting to 'user'
            $table->rememberToken(); // Remember token column for "remember me" functionality
            $table->timestamps(); // Timestamps columns for created_at and updated_at
        });

        // Creates the 'password_reset_tokens' table with columns
        Schema::create('password_reset_tokens', function (Blueprint $table) {
            $table->string('username')->primary(); // Primary key column for username
            $table->string('token'); // Column for reset token
            $table->timestamp('created_at')->nullable(); // Nullable timestamp column for token creation time
        });

        // Creates the 'sessions' table with columns
        Schema::create('sessions', function (Blueprint $table) {
            $table->string('id')->primary(); // Primary key column for session ID
            $table->foreignId('user_id')->nullable()->index(); // Nullable foreign key column for user ID, indexed for faster lookups
            $table->string('ip_address', 45)->nullable(); // Nullable IP address column, maximum length of 45 characters
            $table->text('user_agent')->nullable(); // Nullable user agent column
            $table->longText('payload'); // Column for session data payload
            $table->integer('last_activity')->index(); // Indexed column for the timestamp of the last activity
        });
    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down(): void
    {   
        // Drops the 'users' table
        Schema::dropIfExists('users');
        // Drops the 'password_reset_tokens' table
        Schema::dropIfExists('password_reset_tokens');
        // Drops the 'sessions' table
        Schema::dropIfExists('sessions');
    }
};
