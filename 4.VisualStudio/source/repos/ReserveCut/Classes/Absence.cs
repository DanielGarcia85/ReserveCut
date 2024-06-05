namespace ReserveCut.Classes
{
    // Classe représentant une absence d'un coiffeur
    public class Absence
    {
        public int id { get; set; }
        public Stylist stylist { get; set; }
        public DateTime date_begin { get; set; }
        public DateTime date_end { get; set; }
    }
}
