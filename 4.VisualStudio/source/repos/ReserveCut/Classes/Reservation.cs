namespace ReserveCut.Classes
{
    // Classe représentant une réservation de service
    public class Reservation
    {
        public int id { get; set; }
        public Customer customer { get; set; }
        public Stylist stylist { get; set; }
        public DateTime date_begin { get; set; }
        public DateTime date_end { get; set; }
        public string comments { get; set; }
        public bool beard_y_n { get; set; }
        public bool shampoo_y_n { get; set; }
    }
}
