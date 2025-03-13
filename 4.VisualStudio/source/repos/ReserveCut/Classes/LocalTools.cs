using System.Globalization;

namespace ReserveCut.Classes
{
    // Classe statique contenant des outils locaux pour l'application
    public static class LocalTools
    {
        // Méthode pour convertir une date en chaîne de caractères au format "yyyy-MM-dd HH:mm"
        public static string ConvertDateFormat(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        }
    }
}
