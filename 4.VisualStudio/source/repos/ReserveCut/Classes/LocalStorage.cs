namespace ReserveCut.Classes
{
    // Classe statique représentant le stockage local pour l'application
    public static class LocalStorage
    {
        public static string token { get; set; } = string.Empty; // Jeton d'accès pour l'authentification
        public static string loggedUserRole { get; set; } = string.Empty; // Rôle de l'utilisateur connecté
        public static int selectedStylistId { get; set; } = 0; // Identifiant du coiffeur sélectionné
        public static DateTime selectedStartDate { get; set; } = DateTime.Now; // Date de début sélectionnée
        public static List<Reservation> reservations; // Liste des réservations
        public static List<Reservation> filteredReservations; // Liste des réservations filtrées
        public static bool areReservationsLoaded = false; // Indicateur si les réservations sont chargées
        public static List<Customer> customers; // Liste des clients
        public static List<Stylist> stylists; // Liste des coiffeurs
        public static List<Absence> absences; // Liste des absences des coiffeurs
        public static List<Haircut> haircuts; // Liste des coupes de cheveux
        public static List<User> users; // Liste des utilisateurs
        public static Reservation selectedReservation { get; set; } // Réservation sélectionnée
        public static User selectedUser { get; set; } // Utilisateur sélectionné
        public static Customer selectedCustomer { get; set; } // Client sélectionné
    }
}
