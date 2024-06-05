namespace ReserveCut
{
    // Classe représentant le formulaire pour ajouter un nouveau coiffeur
    public partial class FrmNewStylist : Form
    {
        // Constructeur de la classe FrmNewStylist
        public FrmNewStylist()
        {
            InitializeComponent(); // Initialise les composants du formulaire

            // Définit le style du ComboBox pour qu'il soit en mode liste déroulante
            cmb_speciality_ns.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Annuler"
        private void btn_cancel_ns_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de nouveau coiffeur
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton pour sélectionner une photo
        private void bnt_photo_ns_Click(object sender, EventArgs e)
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
        private void btn_add_ns_Click(object sender, EventArgs e)
        {
            FrmAddConfirmation frmAddConfirmation = new FrmAddConfirmation(); // Crée une nouvelle instance du formulaire de confirmation d'ajout
            frmAddConfirmation.ShowDialog(); // Affiche le formulaire de confirmation d'ajout en tant que boîte de dialogue modale

            // Réinitialise les champs du formulaire
            txb_name_ns.Text = "";
            txb_firstname_ns.Text = "";
            cmb_speciality_ns.SelectedIndex = -1; // Réinitialise la sélection de la liste déroulante
            lst_speciality_ns.Items.Clear(); // Vide la liste des spécialités
        }

        // Méthode déclenchée lors du chargement initial du formulaire de nouveau coiffeur
        private void FrmNewStylist_Load(object sender, EventArgs e)
        {
            txb_name_ns.Focus(); // Donne le focus au champ du nom du coiffeur pour faciliter la saisie
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton pour ajouter une spécialité
        private void btn_addspeciality_ns_Click(object sender, EventArgs e)
        {
            string speciality = cmb_speciality_ns.Text; // Récupère la spécialité sélectionnée

            // Vérifie si la spécialité n'est pas déjà dans la liste
            if (!lst_speciality_ns.Items.Contains(speciality))
            {
                lst_speciality_ns.Items.Add(speciality); // Ajoute la spécialité à la liste
            }
            else
            {
                MessageBox.Show($"{speciality} est déjà ajouté.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); // Affiche un message si la spécialité est déjà dans la liste
            }
        }
    }
}
