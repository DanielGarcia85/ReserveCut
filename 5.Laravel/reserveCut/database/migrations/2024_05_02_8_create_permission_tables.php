<?php

// Import the Schema facade to interact with the database schema
use Illuminate\Support\Facades\Schema;
// Import the Blueprint class to define the schema of the tables
use Illuminate\Database\Schema\Blueprint;
// Import the base Migration class to define database migrations
use Illuminate\Database\Migrations\Migration;

// Define an anonymous class extending the base Migration class for handling database changes
return new class extends Migration
{
    /**
     * Run the migrations.
     * This method performs the setup or installation process for the database by creating and configuring tables for roles, permissions, and their relationships with users and teams.
     * It includes checks for necessary configurations and creates tables with appropriate constraints to manage access control across the application.
     */
    public function up(): void
    {
        // Load team settings from permission configuration
        $teams = config('permission.teams');
        // Load table names from permission configuration
        $tableNames = config('permission.table_names');
        // Load column names from permission configuration
        $columnNames = config('permission.column_names');
        // Define default keys for role and permission IDs with fallbacks if not set
        $pivotRole = $columnNames['role_pivot_key'] ?? 'role_id';
        $pivotPermission = $columnNames['permission_pivot_key'] ?? 'permission_id';
        // Check if table names are not configured.
        if (empty($tableNames)) {
            // Throw exceptions if required configurations are missing
            throw new \Exception('Error: config/permission.php not loaded. Run [php artisan config:clear] and try again.');
        }
        // Check if team foreign key is not set when teams are used
        if ($teams && empty($columnNames['team_foreign_key'] ?? null)) {
            // Throw exceptions if required configurations are missing
            throw new \Exception('Error: team_foreign_key on config/permission.php not loaded. Run [php artisan config:clear] and try again.');
        }
        // Create the permissions table with specified columns and constraints
        Schema::create($tableNames['permissions'], function (Blueprint $table) {
            $table->bigIncrements('id'); // Define an auto-incrementing ID
            $table->string('name'); // Permission name
            $table->string('guard_name'); // Guard name for the permission
            $table->timestamps(); // Timestamps for created_at and updated_at
            $table->unique(['name', 'guard_name']); // Ensure the combination of name and guard_name is unique
        });
        // Create the roles table with possible support for teams and specified constraints
        Schema::create($tableNames['roles'], function (Blueprint $table) use ($teams, $columnNames) {
            $table->bigIncrements('id');  //Define an auto-incrementing ID
            // Conditionally add a team_foreign_key if teams are used or if it's a testing environment
            if ($teams || config('permission.testing')) {
                $table->unsignedBigInteger($columnNames['team_foreign_key'])->nullable();
                $table->index($columnNames['team_foreign_key'], 'roles_team_foreign_key_index');
            }
            $table->string('name'); // Role name
            $table->string('guard_name'); // Guard name for the role
            $table->timestamps(); // Timestamps for created_at and updated_at
            if ($teams || config('permission.testing')) {
                // Set unique constraint on team, name, and guard_name combination
                $table->unique([$columnNames['team_foreign_key'], 'name', 'guard_name']);
            } else {
                // Set unique constraint on name and guard_name
                $table->unique(['name', 'guard_name']);
            }
        });
        // Define model_has_permissions table with the appropriate relationships and primary keys
        Schema::create($tableNames['model_has_permissions'], function (Blueprint $table) use ($tableNames, $columnNames, $pivotPermission, $teams) {
            $table->unsignedBigInteger($pivotPermission);// Add a column for permission IDs
            $table->string('model_type'); // Add a column for storing the model type
            $table->unsignedBigInteger($columnNames['model_morph_key']); // Add a column for model ID, supporting polymorphic relations
            $table->index([$columnNames['model_morph_key'], 'model_type'], 'model_has_permissions_model_id_model_type_index'); // Index for faster query performance
            $table->foreign($pivotPermission) // Set a foreign key on the permission ID
                ->references('id') // Reference the ID column in permissions table
                ->on($tableNames['permissions']) // The foreign key references the permissions table
                ->onDelete('cascade'); // Delete related entries on permission deletion
            if ($teams) {
                $table->unsignedBigInteger($columnNames['team_foreign_key']); // Add a team foreign key if teams are enabled
                $table->index($columnNames['team_foreign_key'], 'model_has_permissions_team_foreign_key_index');// Index the team foreign key
                $table->primary([$columnNames['team_foreign_key'], $pivotPermission, $columnNames['model_morph_key'], 'model_type'],
                    'model_has_permissions_permission_model_type_primary'); // Set a composite primary key for team setups
            } else {
                $table->primary([$pivotPermission, $columnNames['model_morph_key'], 'model_type'],
                    'model_has_permissions_permission_model_type_primary'); // Set a composite primary key for non-team setups
            }

        });
        // Create the model_has_roles table with fields and constraints
        Schema::create($tableNames['model_has_roles'], function (Blueprint $table) use ($tableNames, $columnNames, $pivotRole, $teams) {
            $table->unsignedBigInteger($pivotRole); // Add a column for role IDs
            $table->string('model_type'); // Add a column for storing the model type
            $table->unsignedBigInteger($columnNames['model_morph_key']); // Add a column for model ID, supporting polymorphic relations
            $table->index([$columnNames['model_morph_key'], 'model_type'], 'model_has_roles_model_id_model_type_index'); // Index for faster query performance
            $table->foreign($pivotRole) // Set a foreign key on the role ID
                ->references('id') // Reference the ID column in roles table
                ->on($tableNames['roles']) // The foreign key references the roles table
                ->onDelete('cascade'); // Delete related entries on role deletion
            if ($teams) {
                $table->unsignedBigInteger($columnNames['team_foreign_key']); // Add a team foreign key if teams are enabled
                $table->index($columnNames['team_foreign_key'], 'model_has_roles_team_foreign_key_index'); // Index the team foreign key
                $table->primary([$columnNames['team_foreign_key'], $pivotRole, $columnNames['model_morph_key'], 'model_type'],
                    'model_has_roles_role_model_type_primary'); // Set a composite primary key for team setups
            } else {
                $table->primary([$pivotRole, $columnNames['model_morph_key'], 'model_type'],
                    'model_has_roles_role_model_type_primary'); // Set a composite primary key for non-team setups
            }
        });
        // Create the role_has_permissions table with fields and constraints
        Schema::create($tableNames['role_has_permissions'], function (Blueprint $table) use ($tableNames, $pivotRole, $pivotPermission) {
            $table->unsignedBigInteger($pivotPermission); // Add a column for permission IDs
            $table->unsignedBigInteger($pivotRole); // Add a column for role IDs

            $table->foreign($pivotPermission) // Set a foreign key on the permission ID
                ->references('id') // Reference the ID column in permissions table
                ->on($tableNames['permissions']) // The foreign key references the permissions table
                ->onDelete('cascade'); // Delete related entries on permission deletion
            $table->foreign($pivotRole) // Set a foreign key on the role ID
                ->references('id') // Reference the ID column in roles table
                ->on($tableNames['roles']) // The foreign key references the roles table
                ->onDelete('cascade');  // Delete related entries on role deletion
            $table->primary([$pivotPermission, $pivotRole], 'role_has_permissions_permission_id_role_id_primary'); // Set a composite primary key
        });
        // Clear the cache for permissions to ensure fresh data
        app('cache')
            ->store(config('permission.cache.store') != 'default' ? config('permission.cache.store') : null)
            ->forget(config('permission.cache.key'));
    }

    /**
     * Reverse the migrations.
     * This method undoes the changes made in the up() method by dropping the created tables, ensuring data integrity during rollbacks.
     */
    public function down(): void
    {
        // Load table names from permission configuration
        $tableNames = config('permission.table_names');
        // Check if the configuration for table names is not set
        if (empty($tableNames)) {
            // Throw an exception if the configuration file is missing or improperly set
            throw new \Exception('Error: config/permission.php not found and defaults could not be merged. Please publish the package configuration before proceeding, or drop the tables manually.');
        }
        // Drop the role_has_permissions table from the database
        Schema::drop($tableNames['role_has_permissions']);
        // Drop the model_has_roles table from the database
        Schema::drop($tableNames['model_has_roles']);
        // Drop the model_has_permissions table from the database
        Schema::drop($tableNames['model_has_permissions']);
        // Drop the roles table from the database
        Schema::drop($tableNames['roles']);
        // Drop the permissions table from the database
        Schema::drop($tableNames['permissions']);
    }
};
