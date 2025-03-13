namespace ReserveCut
{
    // Classe représentant le formulaire d'erreur de connexion
    public partial class FrmLoginError : Form
    {
        // Constructeur de la classe FrmLoginError
        public FrmLoginError()
        {
            InitializeComponent(); // Initialise les composants du formulaire
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "OK"
        private void btn_ok_le_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire d'erreur de connexion
        }

        // Méthode déclenchée lors du chargement initial du formulaire d'erreur de connexion
        private void FrmLoginError_Load(object sender, EventArgs e)
        {
            btn_ok_le.Focus(); // Donne le focus au bouton "OK" pour que l'utilisateur puisse facilement appuyer sur "Entrée" pour fermer le formulaire
        }
    }
}
