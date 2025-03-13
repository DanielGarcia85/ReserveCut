namespace ReserveCut.Classes
{
    // Classe représentant un jeton d'accès pour l'authentification et l'utilisateur associé
    public class AccessToken
    {
        public string message { get; set; }
        public string token { get; set; }
        public string token_type { get; set; }
        public User user { get; set; }
    }
}
