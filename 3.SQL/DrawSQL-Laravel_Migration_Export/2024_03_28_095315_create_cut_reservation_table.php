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

        Schema::create('cut_reservation', function (Blueprint $table) {
            $table->id();
            $table->unsignedBigInteger('res_cli_id')->index();
            $table->foreign('res_cli_id')->references('cus_id')->on('cut_customer');
            $table->unsignedBigInteger('res_sty_id')->index()->nullable();
            $table->foreign('res_sty_id')->references('sty_id')->on('cut_stylist');
            $table->dateTime('res_dateBegin');
            $table->dateTime('res_dateEnd');
            $table->string('res_comments', 255)->nullable();
            $table->boolean('res_beard_y_n')->nullable();
            $table->boolean('res_shampoo_y_n')->nullable();
            $table->string('res_status', 64);
        });

        Schema::enableForeignKeyConstraints();
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('cut_reservation');
    }
};
