<?php

// Declares the namespace for the User model, grouping it logically within the App\Models namespace
namespace App\Models;

// Imports the HasFactory trait for enabling model factories
use Illuminate\Database\Eloquent\Factories\HasFactory;
// Extends the base Authenticatable class for user authentication
use Illuminate\Foundation\Auth\User as Authenticatable;
// Imports Notifiable trait to send notifications to the user
use Illuminate\Notifications\Notifiable;
// Import the HasApiTokens trait from the Laravel Sanctum package, in order to provides methods to manage API tokens for users
use Laravel\Sanctum\HasApiTokens;
// Import the HasRoles trait to enable role and permission checks on Eloquent models
use Spatie\Permission\Traits\HasRoles;

/**
 * Defines the User model, which extends the Authenticatable class provided by Laravel.
 */
class User extends Authenticatable
{
    // Utilizes the HasFactory, Notifiable, HasApiTokens and HasRole traits
    use HasFactory, Notifiable, HasApiTokens, HasRoles;

    /**
     * The attributes that are mass assignable.
     * Specifies which attributes can be mass assigned safely in bulk operations.
     *
     * @var array<int, string> // Defines the type of the array elements.
     */
    protected $fillable = [
        'name',
        'firstname',
        'username',
        'password',
        'role',
    ];

    /**
     * The attributes that should be hidden for serialization.
     * Specifies which attributes should not be visible in responses or arrays when the model is serialized.
     *
     * @var array<int, string> // Defines the type of the array elements.
     */
    protected $hidden = [
        'password',
        'remember_token',
        'created_at',
        'updated_at',
    ];

    /**
     * Get the attributes that should be cast to native types.
     * Specifies how attributes should be cast when accessing them on the model.
     *
     * @return array<string, string> // Indicates the return type of the method.
     */
    protected function casts(): array
    {
        return [
            'password' => 'hashed', // Casts 'password' to a hashed value
        ];
    }

    /**
     * Get the name of the unique identifier for the user.
     *
     * @return string //The name of the unique identifier for the user.
     */
    public function getAuthIdentifierName()
    {
        return 'username';
    }
}
