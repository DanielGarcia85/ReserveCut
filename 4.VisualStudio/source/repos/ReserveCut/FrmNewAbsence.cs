namespace ReserveCut
{
    // Classe représentant le formulaire pour ajouter une nouvelle absence
    public partial class FrmNewAbsence : Form
    {
        // Constructeur de la classe FrmNewAbsence
        public FrmNewAbsence()
        {
            InitializeComponent(); // Initialise les composants du formulaire
        }

        // Méthode déclenchée lors du chargement initial du formulaire de nouvelle absence
        private void FrmNewAbsence_Load(object sender, EventArgs e)
        {
            dtp_begindate_na.Focus(); // Donne le focus au contrôle DateTimePicker pour la date de début de l'absence
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Ajouter"
        private void btn_add_na_Click(object sender, EventArgs e)
        {
            FrmAddConfirmation frmAddConfirmation = new FrmAddConfirmation(); // Crée une nouvelle instance du formulaire de confirmation d'ajout
            frmAddConfirmation.ShowDialog(); // Affiche le formulaire de confirmation d'ajout en tant que boîte de dialogue modale
            this.Close(); // Ferme le formulaire de nouvelle absence
        }
    }
}
