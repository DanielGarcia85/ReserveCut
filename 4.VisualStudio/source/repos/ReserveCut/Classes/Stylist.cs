namespace ReserveCut.Classes
{
    // Classe représentant un coiffeur
    public class Stylist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public string photo_path { get; set; }
        public List<Haircut> haircuts { get; set; }
        public List<Reservation> reservations { get; set; }
        public List<Absence> absences { get; set; }
        public string fullName { get {return $"{firstname} {name}"; } }
    }
}