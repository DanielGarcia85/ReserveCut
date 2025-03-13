namespace ReserveCut.Classes
{
    // Classe représentant une coupe de cheveux
    public class Haircut
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool long_short { get; set; }
        public int cutting_time { get; set; }
        public double price { get; set; }
        public string photo_path { get; set; }

    }
}
