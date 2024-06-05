<?php

// Declare the namespace to organize and group related classes under the App\Models namespace
namespace App\Models;

// Imports the HasFactory trait for factory-based seeding functionality
use Illuminate\Database\Eloquent\Factories\HasFactory;
// Imports the base Model class for Eloquent model definitions
use Illuminate\Database\Eloquent\Model;

/**
 * Defines the Stylist model, representing a Stylist record in the database.
 */
class Stylist extends Model
{
    // Includes methods from the HasFactory trait to enable model factory features
    use HasFactory;

    // Specifies which attributes can be mass assigned
    protected $fillable = [
        'name',
        'firstname',
        'photo_path'
    ];

    // Specifies which attributes should be hidden when the model is converted to JSON
    protected $hidden = [
        'created_at',
        'updated_at'
    ];

    /**
     * Defines a relationship to the Absence model.
     *
     * @return \Illuminate\Database\Eloquent\Relations\HasMany // Specifies the return type of the method.
     */
    public function absences()
    {
        // Specifies (and return) that a Stylist record has many Absence (1-n relation)
        return $this->hasMany(Absence::class);
    }

    /**
     * Defines a relationship to the Reservation model.
     *
     * @return \Illuminate\Database\Eloquent\Relations\HasMany // Specifies the return type of the method.
     */
    public function reservations()
    {
        // Specifies (and return) that a Stylist record has many Reservation (1-n relation)
        return $this->hasMany(Reservation::class);
    }

    /**
     * Defines a many-to-many relationship between Stylists and Haircuts.
     *
     * @return \Illuminate\Database\Eloquent\Relations\BelongsToMany // Specifies the return type of the method.
     */
    public function haircuts()
    {
        // Specifies (and return) a many-to-many relationship between Stylists and Haircuts (n-n relation)
        return $this->belongsToMany(Haircut::class);
    }
}
