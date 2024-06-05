<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        
        Schema::create('cut_haircut', function (Blueprint $table) {
            $table->id();
            $table->string('hai_name', 64)->unique();
            $table->string('hai_description', 255)->nullable();
            $table->boolean('hai_long_short')->nullable();
            $table->time('hai_cuttingTime');
            $table->double('hai_prix');
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('cut_haircut');
    }
};
