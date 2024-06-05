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

        Schema::create('cut_customer', function (Blueprint $table) {
            $table->id();
            $table->string('cus_name', 64);
            $table->string('cus_firstName', 64);
            $table->string('cus_address', 64)->nullable();
            $table->bigInteger('cus_npa')->nullable();
            $table->string('cus_city', 64)->nullable();
            $table->bigInteger('cus_tel');
            $table->string('cus_email', 255)->nullable();
            $table->date('cus_datebirth')->nullable();
            $table->string('cus_photo', 255)->nullable();
            $table->unsignedBigInteger('cus_hai_id')->index()->nullable();
            $table->foreign('cus_hai_id')->references('hai_id')->on('cut_haircut');
            $table->string('cus_pref_contact', 64)->nullable();
        });

        Schema::enableForeignKeyConstraints();
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('cut_customer');
    }
};
