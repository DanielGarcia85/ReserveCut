# ReserveCut

**ReserveCut** is a reservation and management application designed for hair salons and barbershops, developed as part of the ***62-41 Architecture*** course at **Haute École de Gestion (HEG)**. This project combines a robust **PHP** backend built with **Laravel** and an interactive **C#** frontend developed in **Visual Studio**.

## Features

- 📅 Appointment Management : Schedule, modify, and cancel reservations.
- 👤 Customer Database : Store client details and preferences.
- 💇 Haircut & Service Catalog : List available haircuts, pricing, and specifications.
- ✂️ Barber & Specialization Management : Assign barbers based on expertise.
- 🔐 User Role & Access Management – Different user roles with access control for managing reservations, customers, and services.

## Project Structure

The project is organized into several folders, reflecting the different development stages:

- **0.Rendu/** : Contains the five milestones submitted to the professor:
- **1.Flyer/** : Initial idea presented as a promotional flyer.
- **2.Logo_Image/** : Logos and images associated with the project.
- **3.SQL/** : Database modeling and SQL scripts.
- **4.VisualStudio/** : Horizontal prototype developed in Visual Studio, containing all application windows.
- **5.Laravel/** : Fully developed backend in PHP using the Laravel framework.

## Prerequisites

Before starting, ensure you have installed:

- **PHP 8.2 or later**: [Download here](https://www.php.net/downloads)
- **Composer**: [Download here](https://getcomposer.org/download/)
- **Laravel 8.x**: [Installation guide](https://laravel.com/docs/8.x/installation)
- **MySQL 10.4 (MariaDB recommended)**: [Download here](https://dev.mysql.com/downloads/)
- **Visual Studio 2022**: [Download here](https://visualstudio.microsoft.com/downloads/)
- **.NET Framework 7.0.102 or later**: [Download here](https://dotnet.microsoft.com/download/dotnet-framework)

## Installation

### Database Setup (MySQL)

1. **Start MySQL** and open **phpMyAdmin** (`http://localhost/phpmyadmin`).
2. **Create the database** manually or execute the provided script:
   - Import the SQL file located in `3.SQL/DanielGarcia_ReserveCut_MPD_DataBase.sql`.
   - Alternatively, in MySQL, run:
     ```sql
     SOURCE path/to//DanielGarcia_ReserveCut_MPD_DataBase.sql;
     ```
   - Make sure the database name matches the one in your Laravel `.env` file

### Backend (Laravel)

1. **Clone the repository**:
   ```shell
   git clone https://github.com/DanielGarcia85/ReserveCut.git
   cd ReserveCut/5.Laravel/reserveCut
   ```
2. **Install depenencies**:
   ```shell
   composer install
   ```
3. Set up environnement
   - Copy the .env.example file to .env
   ```shell
   cp .env.example .env
   ```
   - Generate the application key:
   ```shell
   php artisan key:generate
   ```
   - Configure database settings in the .env file.
4. Migrate the database
   ```shell
   php artisan migrate
   ```
5. Start the development server
   ```shell
   php artisan serve
   ```

### Frontend (Visual Studio)

1. Open the project:
   - Launch **Visual Studio**.
   - Open the solution file located in *4.VisualStudio\source\repos\ReserveCut\ReserveCut.sln*.
3. Restore NuGet packages:
   - Right-click on the solution in **Solution Explorer**.
   - Select *Restore NuGet Packages*.
5. Configure backend connection:
   - Open the appropriate configuration file.
   - Ensure the API URL points to the Laravel backend.
7. Run the application
   - Click *Start* or press F5.

### Project Status
- **Backend Laravel** : 100% completed
- **Frontend Visual Studio** : 70% completed. Some features are still unde development. The UI is completly finished.

### Usage

Since the project is not yet fully completed, there is currently no standalone executable file (.exe, .dmg, etc.). To test the application, launch the frontend directly from Visual Studio in debug mode, allowing it to interact with the running Laravel backend.

### Useful Resources

- Laravel Documentation: [Download here](https://laravel.com/docs/8.x)
- Visual Studio Documentation: [Download here](https://docs.microsoft.com/en-us/visualstudio/)
- .NET Framework Documentation: [Download here](https://docs.microsoft.com/en-us/dotnet/framework/)

## License
This project is licensed under the **Creative Commons Attribution-ShareAlike (CC BY-SA)** license.

### Author
Project created by **Daniel Garcia** as part of the ***62-41 Architecture*** course at **Haute École de Gestion (HEG)** during the Spring semester of 2024.



