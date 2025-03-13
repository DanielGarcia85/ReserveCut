namespace ReserveCut
{
    // Classe représentant le formulaire de confirmation de modification
    public partial class FrmModificationConfirmation : Form
    {
        // Constructeur de la classe FrmModificationConfirmation
        public FrmModificationConfirmation()
        {
            InitializeComponent(); // Initialise les composants du formulaire
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "OK"
        private void btn_ok_mc_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de confirmation de modification
        }

        // Méthode déclenchée lors du chargement initial du formulaire de confirmation de modification
        private void FrmModificationConfirmation_Load(object sender, EventArgs e)
        {
            btn_ok_mc.Focus(); // Donne le focus au bouton "OK" pour que l'utilisateur puisse facilement appuyer sur "Entrée" pour fermer le formulaire
        }
    }
}
