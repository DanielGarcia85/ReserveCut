<?php

// Declare the namespace to organize and group related classes under the App\Models namespace
namespace App\Models;

// Imports the HasFactory trait for factory-based seeding functionality
use Illuminate\Database\Eloquent\Factories\HasFactory;
// Imports the base Model class for Eloquent model definitions
use Illuminate\Database\Eloquent\Model;

/**
 * Defines the Customer model, representing a Customer record in the database.
 */
class Customer extends Model
{
    // Includes methods from the HasFactory trait to enable model factory features
    use HasFactory;

    // Specifies which attributes can be mass assigned
    protected $fillable = [
        'name',
        'firstname',
        'address',
        'postcode',
        'city',
        'phone',
        'email',
        'date_birth',
        'photo_path',
        'haircut_id',
        'pref_contact'
    ];

    // Specifies which attributes should be hidden when the model is converted to JSON
    protected $hidden = [
        'created_at',
        'updated_at'
    ];

    /**
     * Defines a relationship to the Reservation model.
     *
     * @return \Illuminate\Database\Eloquent\Relations\HasMany // Specifies the return type of the method.
     */
    public function reservations()
    {
        // Specifies (and return) that a Customer record has many Reservation (1-n relation)
        return $this->hasMany(Reservation::class);
    }

    /**
     * Defines a relationship to the Haircut model.
     *
     * @return \Illuminate\Database\Eloquent\Relations\BelongsTo // Specifies the return type of the method.
     */
    public function haircut()
    {
        // Specifies (and return) that a Customer record belongs to a Haircut (n-1 relation)
        return $this->belongsTo(Haircut::class);
    }
}
