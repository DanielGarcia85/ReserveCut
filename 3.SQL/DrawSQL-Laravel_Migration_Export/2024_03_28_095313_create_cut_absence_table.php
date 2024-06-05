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
        Schema::disableForeignKeyConstraints();

        Schema::create('cut_absence', function (Blueprint $table) {
            $table->id();
            $table->unsignedBigInteger('abs_sty_id')->index();
            $table->foreign('abs_sty_id')->references('sty_id')->on('cut_stylist');
            $table->date('abs_dateBegin');
            $table->date('abs_dateEnd');
        });

        Schema::enableForeignKeyConstraints();
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('cut_absence');
    }
};
