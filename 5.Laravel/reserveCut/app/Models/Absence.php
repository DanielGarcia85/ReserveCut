<?php

// Declare the namespace to organize and group related classes under the App\Models namespace
namespace App\Models;

// Imports the HasFactory trait for factory-based seeding functionality
use Illuminate\Database\Eloquent\Factories\HasFactory;
// Imports the base Model class for Eloquent model definitions
use Illuminate\Database\Eloquent\Model;

/**
 * Defines the Absence model, representing an Absence record in the database.
 */
class Absence extends Model
{
    // Includes methods from the HasFactory trait to enable model factory features
    use HasFactory;

    // Specifies which attributes can be mass assigned
    protected $fillable = [
        'stylist_id',
        'date_begin',
        'date_end'
    ];

    // Specifies which attributes should be hidden when the model is converted to JSON
    protected $hidden = [
        'created_at',
        'updated_at'
    ];

    /**
     * Defines a relationship to the Stylist model.
     *
     * @return \Illuminate\Database\Eloquent\Relations\BelongsTo // Specifies the return type of the method.
     */
    public function stylist()
    {
        // Specifies (and return) that an Absence record belongs to a Stylist (n-1 relation)
        return $this->belongsTo(Stylist::class);
    }

}
