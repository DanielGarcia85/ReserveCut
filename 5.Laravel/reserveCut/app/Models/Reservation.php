<?php

// Declare the namespace to organize and group related classes under the App\Models namespace
namespace App\Models;

// Imports the HasFactory trait for factory-based seeding functionality
use Illuminate\Database\Eloquent\Factories\HasFactory;
// Imports the base Model class for Eloquent model definitions
use Illuminate\Database\Eloquent\Model;

/**
 * Defines the Reservation model, representing a Reservation record in the database.
 */
class Reservation extends Model
{
    // Includes methods from the HasFactory trait to enable model factory features
    use HasFactory;

    // Specifies which attributes can be mass assigned
    protected $fillable = [
        'customer_id',
        'stylist_id',
        'date_begin',
        'date_end',
        'comments',
        'beard_y_n',
        'shampoo_y_n'
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
        // Specifies (and return) that a Reservation record belongs to a Stylist (n-1 relation)
        return $this->belongsTo(Stylist::class);
    }

    /**
     * Defines a relationship to the Customer model.
     *
     * @return \Illuminate\Database\Eloquent\Relations\BelongsTo // Specifies the return type of the method.
     */
    public function customer()
    {
        // Specifies (and return) that a Reservation record belongs to a Customer (n-1 relation)
        return $this->belongsTo(Customer::class);
    }
}
