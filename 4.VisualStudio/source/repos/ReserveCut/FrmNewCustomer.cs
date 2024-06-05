namespace ReserveCut
{
    // Classe représentant le formulaire pour ajouter un nouveau client
    public partial class FrmNewCustomer : Form
    {
        // Constructeur de la classe FrmNewCustomer
        public FrmNewCustomer()
        {
            InitializeComponent(); // Initialise les composants du formulaire

            // Définit le style des ComboBox pour qu'ils soient en mode liste déroulante
            cmb_contact_nc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_haricut_nc.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Annuler"
        private void btn_cancel_nc_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de nouveau client
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton pour sélectionner une photo
        private void bnt_photo_nc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Images (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"; // Filtre les fichiers pour n'afficher que les images
            openFileDialog.Title = "Sélectionnez un fichier"; // Définit le titre de la boîte de dialogue

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Ici, traiter l'image
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Ajouter"
        private void btn_add_nc_Click(object sender, EventArgs e)
        {
            FrmAddConfirmation frmAddConfirmation = new FrmAddConfirmation(); // Crée une nouvelle instance du formulaire de confirmation d'ajout
            frmAddConfirmation.ShowDialog(); // Affiche le formulaire de confirmation d'ajout en tant que boîte de dialogue modale

            // Réinitialise les champs du formulaire
            txb_name_nc.Text = "";
            txb_firstname_nc.Text = "";
            txb_address_nc.Text = "";
            txb_city_nc.Text = "";
            txb_npa_nc.Text = "";
            txb_phone_nc.Text = "";
            txb_mail_nc.Text = "";
            dtp_birthdate_nc.Text = "";
            cmb_contact_nc.SelectedIndex = -1; // Réinitialise la sélection de la liste déroulante
            cmb_haricut_nc.SelectedIndex = -1; // Réinitialise la sélection de la liste déroulante
        }

        // Méthode déclenchée lors du chargement initial du formulaire de nouveau client
        private void FrmNewCustomer_Load(object sender, EventArgs e)
        {
            txb_name_nc.Focus(); // Donne le focus au champ du nom du client pour faciliter la saisie
        }
    }
}
