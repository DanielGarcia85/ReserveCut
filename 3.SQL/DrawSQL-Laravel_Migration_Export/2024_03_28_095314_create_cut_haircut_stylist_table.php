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

        Schema::create('cut_haircut_stylist', function (Blueprint $table) {
            $table->id();
            $table->unsignedBigInteger('hcs_sty_id')->index();
            $table->foreign('hcs_sty_id')->references('sty_id')->on('cut_stylist');
            $table->unsignedBigInteger('hcs_hai_id')->index();
            $table->foreign('hcs_hai_id')->references('hai_id')->on('cut_haircut');
        });

        Schema::enableForeignKeyConstraints();
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('cut_haircut_stylist');
    }
};
