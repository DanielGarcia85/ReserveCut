namespace ReserveCut
{
    // Classe représentant le formulaire de confirmation de mot de passe
    public partial class FrmPasswordConfirmation : Form
    {
        private string initialPassword; // Mot de passe initial à confirmer

        // Constructeur de la classe FrmPasswordConfirmation
        public FrmPasswordConfirmation(string initialPassword)
        {
            InitializeComponent(); // Initialise les composants du formulaire
            this.initialPassword = initialPassword; // Initialise le mot de passe initial
        }

        // Méthode déclenchée lors du chargement initial du formulaire de confirmation de mot de passe
        private void FrmPasswordConfirmation_Load(object sender, EventArgs e)
        {
            
        }

        // Propriété indiquant si le mot de passe a été confirmé
        public bool IsPasswordConfirmed { get; private set; } = false;

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Confirmer"
        private void btn_confirm_pc_Click(object sender, EventArgs e)
        {
            // Vérifie si le mot de passe saisi correspond au mot de passe initial
            if (txb_password_pc.Text == initialPassword)
            {
                IsPasswordConfirmed = true; // Définit la propriété IsPasswordConfirmed à true
                this.Close(); // Ferme le formulaire de confirmation de mot de passe
            }
            else
            {
                // Affiche un message d'erreur si les mots de passe ne correspondent pas
                MessageBox.Show("Les mots de passe ne correspondent pas\n                 Veuillez réessayer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txb_password_pc.Clear(); // Vide le champ de mot de passe
                txb_password_pc.Focus(); // Redonne le focus au champ de mot de passe
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Annuler"
        private void btn_cancel_pc_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de confirmation de mot de passe
        }
    }
}
