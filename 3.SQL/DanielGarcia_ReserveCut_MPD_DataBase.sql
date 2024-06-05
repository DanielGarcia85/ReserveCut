CREATE TABLE `cut_haircut`(
    `hai_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `hai_name` VARCHAR(64) NOT NULL,
    `hai_description` VARCHAR(255) NULL,
    `hai_long_short` TINYINT(1) NULL,
    `hai_cuttingTime` TIME NOT NULL,
    `hai_prix` DOUBLE NOT NULL
);
ALTER TABLE
    `cut_haircut` ADD UNIQUE `cut_haircut_hai_name_unique`(`hai_name`);
CREATE TABLE `cut_customer`(
    `cus_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `cus_name` VARCHAR(64) NOT NULL,
    `cus_firstName` VARCHAR(64) NOT NULL,
    `cus_address` VARCHAR(64) NULL,
    `cus_npa` BIGINT NULL,
    `cus_city` VARCHAR(64) NULL,
    `cus_tel` BIGINT NOT NULL,
    `cus_email` VARCHAR(255) NULL,
    `cus_datebirth` DATE NULL,
    `cus_photo` VARCHAR(255) NULL,
    `cus_hai_id` BIGINT UNSIGNED NULL,
    `cus_pref_contact` VARCHAR(64) NULL
);
ALTER TABLE
    `cut_customer` ADD INDEX `cut_customer_cus_hai_id_index`(`cus_hai_id`);
CREATE TABLE `cut_absence`(
    `abs_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `abs_sty_id` BIGINT UNSIGNED NOT NULL,
    `abs_dateBegin` DATE NOT NULL,
    `abs_dateEnd` DATE NOT NULL
);
ALTER TABLE
    `cut_absence` ADD INDEX `cut_absence_abs_sty_id_index`(`abs_sty_id`);
CREATE TABLE `cut_haircut_stylist`(
    `hcs_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `hcs_sty_id` BIGINT UNSIGNED NOT NULL,
    `hcs_hai_id` BIGINT UNSIGNED NOT NULL
);
ALTER TABLE
    `cut_haircut_stylist` ADD INDEX `cut_haircut_stylist_hcs_sty_id_index`(`hcs_sty_id`);
ALTER TABLE
    `cut_haircut_stylist` ADD INDEX `cut_haircut_stylist_hcs_hai_id_index`(`hcs_hai_id`);
CREATE TABLE `cut_reservation`(
    `res_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `res_cli_id` BIGINT UNSIGNED NOT NULL,
    `res_sty_id` BIGINT UNSIGNED NULL,
    `res_dateBegin` DATETIME NOT NULL,
    `res_dateEnd` DATETIME NOT NULL,
    `res_comments` VARCHAR(255) NULL,
    `res_beard_y_n` TINYINT(1) NULL,
    `res_shampoo_y_n` TINYINT(1) NULL,
    `res_status` VARCHAR(64) NOT NULL
);
ALTER TABLE
    `cut_reservation` ADD INDEX `cut_reservation_res_cli_id_index`(`res_cli_id`);
ALTER TABLE
    `cut_reservation` ADD INDEX `cut_reservation_res_sty_id_index`(`res_sty_id`);
CREATE TABLE `cut_stylist`(
    `sty_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `sty_name` VARCHAR(64) NOT NULL,
    `sty_firstName` VARCHAR(64) NOT NULL
);
ALTER TABLE
    `cut_reservation` ADD CONSTRAINT `cut_reservation_res_cli_id_foreign` FOREIGN KEY(`res_cli_id`) REFERENCES `cut_customer`(`cus_id`);
ALTER TABLE
    `cut_haircut_stylist` ADD CONSTRAINT `cut_haircut_stylist_hcs_hai_id_foreign` FOREIGN KEY(`hcs_hai_id`) REFERENCES `cut_haircut`(`hai_id`);
ALTER TABLE
    `cut_customer` ADD CONSTRAINT `cut_customer_cus_hai_id_foreign` FOREIGN KEY(`cus_hai_id`) REFERENCES `cut_haircut`(`hai_id`);
ALTER TABLE
    `cut_absence` ADD CONSTRAINT `cut_absence_abs_sty_id_foreign` FOREIGN KEY(`abs_sty_id`) REFERENCES `cut_stylist`(`sty_id`);
ALTER TABLE
    `cut_haircut_stylist` ADD CONSTRAINT `cut_haircut_stylist_hcs_sty_id_foreign` FOREIGN KEY(`hcs_sty_id`) REFERENCES `cut_stylist`(`sty_id`);
ALTER TABLE
    `cut_reservation` ADD CONSTRAINT `cut_reservation_res_sty_id_foreign` FOREIGN KEY(`res_sty_id`) REFERENCES `cut_stylist`(`sty_id`);