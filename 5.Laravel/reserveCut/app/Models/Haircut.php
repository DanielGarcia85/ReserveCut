<?php

// Declare the namespace to organize and group related classes under the App\Models namespace
namespace App\Models;

// Imports the HasFactory trait for factory-based seeding functionality
use Illuminate\Database\Eloquent\Factories\HasFactory;
// Imports the base Model class for Eloquent model definitions
use Illuminate\Database\Eloquent\Model;;

/**
 * Defines the Haircut model, representing a Haircut record in the database.
 */
class Haircut extends Model
{
    // Includes methods from the HasFactory trait to enable model factory features
    use HasFactory;

    // Specifies which attributes can be mass assigned
    protected $fillable = [
        'name',
        'description',
        'long_short',
        'cutting_time',
        'price',
        'photo_path'
    ];

    // Specifies which attributes should be hidden when the model is converted to JSON
    protected $hidden = [
        'created_at',
        'updated_at'
    ];

    /**
     * Defines a relationship to the Customer model.
     *
     * @return \Illuminate\Database\Eloquent\Relations\HasMany // Specifies the return type of the method.
     */
    public function customers()
    {
        // Specifies (and return) that a Haircut record has many Customer (1-n relation)
        return $this->hasMany(Customer::class);
    }

    /**
     * Defines a many-to-many relationship between Haircuts and Stylists.
     *
     * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany // Specifies the return type of the method.
     */
    public function stylists()
    {
        // Specifies (and return) a many-to-many relationship between Haircuts and Stylists (n-n relation)
        return $this->belongsToMany(Stylist::class);
    }
}
