namespace ReserveCut.Classes
{
    // Classe représentant un client
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public string address { get; set; }
        public int postcode { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public DateTime date_birth { get; set; }
        public string photo_path { get; set; }
        public string pref_contact { get; set; }
        public Haircut haircut { get; set; }
        public List<Reservation> reservations { get; set; }
        public string fullName { get { return $"{firstname} {name}"; } }
    }
}
