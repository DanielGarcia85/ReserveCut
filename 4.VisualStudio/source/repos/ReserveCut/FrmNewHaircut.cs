namespace ReserveCut
{
    // Classe représentant le formulaire pour ajouter une nouvelle coupe de cheveux
    public partial class FrmNewHaircut : Form
    {
        // Constructeur de la classe FrmNewHaircut
        public FrmNewHaircut()
        {
            InitializeComponent(); // Initialise les composants du formulaire

            // Définit le style des ComboBox pour qu'ils soient en mode liste déroulante
            cmb_shortlong_nh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_cutingtime_nh.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Annuler"
        private void btn_cancel_nh_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de nouvelle coupe de cheveux
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton pour sélectionner une photo
        private void bnt_photo_nh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Images (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"; // Filtre les fichiers pour n'afficher que les images
            openFileDialog.Title = "Sélectionnez un fichier"; // Définit le titre de la boîte de dialogue

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Traiter l'image sélectionnée
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Ajouter"
        private void btn_add_nh_Click(object sender, EventArgs e)
        {
            FrmAddConfirmation frmAddConfirmation = new FrmAddConfirmation(); // Crée une nouvelle instance du formulaire de confirmation d'ajout
            frmAddConfirmation.ShowDialog(); // Affiche le formulaire de confirmation d'ajout en tant que boîte de dialogue modale

            // Réinitialise les champs du formulaire
            txb_name_nh.Text = "";
            txb_description_nh.Text = "";
            cmb_cutingtime_nh.SelectedIndex = -1; // Réinitialise la sélection de la liste déroulante
            cmb_shortlong_nh.SelectedIndex = -1; // Réinitialise la sélection de la liste déroulante
            txb_price_nh.Text = "";
        }

        // Méthode déclenchée lors du chargement initial du formulaire de nouvelle coupe de cheveux
        private void FrmNewHaircut_Load(object sender, EventArgs e)
        {
            txb_name_nh.Focus(); // Donne le focus au champ du nom de la coupe de cheveux pour faciliter la saisie
        }
    }
}
