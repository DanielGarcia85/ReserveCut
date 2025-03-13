using ReserveCut.Classes;

namespace ReserveCut
{
    // Classe représentant le formulaire de gestion des utilisateurs
    public partial class FrmUsers : Form
    {
        private int previousSelectedIndex; // Stocke l'index sélectionné précédemment

        // Constructeur de la classe FrmUsers
        public FrmUsers()
        {
            InitializeComponent(); // Initialise les composants du formulaire
        }

        // Méthode déclenchée lors du chargement initial du formulaire de gestion des utilisateurs
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            txb_name_us.Focus(); // Donne le focus au champ du nom de l'utilisateur pour faciliter la saisie
            LoadUsers(); // Charge la liste des utilisateurs
        }

        // Charge la liste des utilisateurs dans le ComboBox
        public void LoadUsers()
        {
            cmb_username_us.Items.Clear(); // Vide le ComboBox des utilisateurs
            foreach (var user in LocalStorage.users)
            {
                cmb_username_us.Items.Add(user.username); // Ajoute chaque nom d'utilisateur au ComboBox
            }
            if (cmb_username_us.Items.Count > 0)
            {
                cmb_username_us.SelectedIndex = 0; // Sélectionne le premier élément si le ComboBox n'est pas vide
            }
        }

        // Méthode déclenchée lorsque la sélection dans le ComboBox des utilisateurs change
        private void cmb_username_us_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_username_us.SelectedItem != null)
            {
                var selectedUsername = cmb_username_us.SelectedItem.ToString(); // Récupère le nom d'utilisateur sélectionné
                var user = LocalStorage.users.FirstOrDefault(u => u.username == selectedUsername); // Trouve l'utilisateur correspondant
                LocalStorage.selectedUser = user; // Stocke l'utilisateur sélectionné
                DisplayUserInfo(user); // Affiche les informations de l'utilisateur
            }
        }

        // Affiche les informations de l'utilisateur dans les champs de texte
        private void DisplayUserInfo(User user)
        {
            if (user != null)
            {
                txb_name_us.Text = user.name;
                txb_firstname_us.Text = user.firstname;
                txb_username_us.Text = user.username;
                txb_password_us.Text = "xxxxxxxx"; // Masque le mot de passe
                txb_role_us.Text = user.role;
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Ajouter"
        private void btn_add_us_Click(object sender, EventArgs e)
        {
            previousSelectedIndex = cmb_username_us.SelectedIndex; // Stocke l'index sélectionné précédemment
            ActivateEditMode(); // Active le mode édition
            // Vide les champs de texte pour l'ajout d'un nouvel utilisateur
            txb_name_us.Text = "";
            txb_firstname_us.Text = "";
            txb_username_us.Text = "";
            txb_password_us.Text = "";
            txb_role_us.Text = "";
            cmb_role_us.SelectedIndex = -1;
            cmb_username_us.SelectedIndex = -1;
            AcceptButton = btn_confirm_us; // Définit le bouton par défaut pour la confirmation
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Modifier"
        private void btn_modify_Click(object sender, EventArgs e)
        {
            previousSelectedIndex = cmb_username_us.SelectedIndex; // Stocke l'index sélectionné précédemment
            ActivateEditMode(); // Active le mode édition
            txb_username_us.Text = cmb_username_us.Text; // Remplit le champ du nom d'utilisateur
            txb_password_us.Text = ""; // Vide le champ du mot de passe
            AcceptButton = btn_confirm_us; // Définit le bouton par défaut pour la confirmation
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Annuler"
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            cmb_username_us.SelectedIndex = previousSelectedIndex; // Rétablit l'index sélectionné précédemment
            ResetUserFields(); // Réinitialise les champs de texte
            DeactivateEditMode(); // Désactive le mode édition
            AcceptButton = btn_close_us; // Définit le bouton par défaut pour la fermeture
        }

        // Réinitialise les champs de texte avec les informations de l'utilisateur sélectionné
        private void ResetUserFields()
        {
            if (cmb_username_us.SelectedIndex != -1)
            {
                var selectedUsername = cmb_username_us.SelectedItem.ToString(); // Récupère le nom d'utilisateur sélectionné
                var user = LocalStorage.users.FirstOrDefault(u => u.username == selectedUsername); // Trouve l'utilisateur correspondant
                LocalStorage.selectedUser = user; // Stocke l'utilisateur sélectionné
                DisplayUserInfo(user); // Affiche les informations de l'utilisateur
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Confirmer"
        private async void btn_confirm_Click(object sender, EventArgs e)
        {
            // Vérifie que tous les champs requis sont remplis
            if (string.IsNullOrWhiteSpace(txb_name_us.Text) ||
                string.IsNullOrWhiteSpace(txb_firstname_us.Text) ||
                string.IsNullOrWhiteSpace(txb_username_us.Text) ||
                string.IsNullOrWhiteSpace(txb_password_us.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérifie que le rôle de l'utilisateur est sélectionné
            if (cmb_role_us.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un rôle", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Affiche le formulaire de confirmation du mot de passe
            FrmPasswordConfirmation frmPasswordConfirmation = new FrmPasswordConfirmation(txb_password_us.Text);
            frmPasswordConfirmation.ShowDialog();

            if (frmPasswordConfirmation.IsPasswordConfirmed)
            {
                User selectedUser = LocalStorage.users.FirstOrDefault(u => u.username == cmb_username_us.Text);
                if (selectedUser != null)
                {
                    // Modification de l'utilisateur existant
                    selectedUser.name = txb_name_us.Text;
                    selectedUser.firstname = txb_firstname_us.Text;
                    selectedUser.username = txb_username_us.Text;
                    selectedUser.password = txb_password_us.Text;
                    selectedUser.role = cmb_role_us.SelectedItem.ToString();
                    bool isSuccess = await Request.UpdateUserAsync(selectedUser);
                    if (isSuccess)
                    {
                        FrmModificationConfirmation frmModificationConfirmation = new FrmModificationConfirmation();
                        frmModificationConfirmation.ShowDialog();
                        LocalStorage.users = await Request.GetUsersAsync();
                        LoadUsers(); // Recharge les utilisateurs dans le ComboBox
                        DeactivateEditMode();
                        cmb_username_us.SelectedIndex = previousSelectedIndex;
                    }
                }
                else
                {
                    // Ajout d'un nouvel utilisateur
                    User newUser = new User
                    {
                        name = txb_name_us.Text,
                        firstname = txb_firstname_us.Text,
                        username = txb_username_us.Text,
                        password = txb_password_us.Text,
                        role = cmb_role_us.SelectedItem.ToString()
                    };
                    bool isSuccess = await Request.AddUserAsync(newUser);
                    if (isSuccess)
                    {
                        FrmAddConfirmation frmAddConfirmation = new FrmAddConfirmation();
                        frmAddConfirmation.ShowDialog();
                        LocalStorage.users = await Request.GetUsersAsync();
                        LoadUsers(); // Recharge les utilisateurs dans le ComboBox
                        DeactivateEditMode();
                        var user = LocalStorage.users.FirstOrDefault(u => u.username == newUser.username);
                        cmb_username_us.SelectedIndex = user.id - 1; // Sélectionne l'utilisateur ajouté
                    }
                }
            }
            AcceptButton = btn_close_us; // Définit le bouton par défaut pour la fermeture
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Supprimer"
        private void btn_delete_us_Click(object sender, EventArgs e)
        {
            FrmDeleteConfirmationRequest frmDeleteConfirmation = new FrmDeleteConfirmationRequest(btn_delete_us, null, null);
            LoadUsers(); // Recharge les utilisateurs dans le ComboBox
            frmDeleteConfirmation.ShowDialog(); // Affiche le formulaire de confirmation de suppression
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Fermer"
        private void btn_close_us_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de gestion des utilisateurs
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Suivant"
        private void btn_next_us_Click(object sender, EventArgs e)
        {
            if (cmb_username_us.SelectedIndex < cmb_username_us.Items.Count - 1)
            {
                cmb_username_us.SelectedIndex++; // Sélectionne l'utilisateur suivant dans le ComboBox
            }
            else
            {
                cmb_username_us.SelectedIndex = 0; // Revient au premier utilisateur si la fin de la liste est atteinte
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Précédent"
        private void btn_previous_us_Click(object sender, EventArgs e)
        {
            if (cmb_username_us.SelectedIndex > 0)
            {
                cmb_username_us.SelectedIndex--; // Sélectionne l'utilisateur précédent dans le ComboBox
            }
            else
            {
                cmb_username_us.SelectedIndex = cmb_username_us.Items.Count - 1; // Revient au dernier utilisateur si le début de la liste est atteint
            }
        }

        // Active le mode édition des champs de texte et des boutons
        private void ActivateEditMode()
        {
            btn_add_us.Visible = false;
            btn_delete_us.Visible = false;
            btn_modify_us.Visible = false;
            btn_confirm_us.Visible = true;
            btn_cancel_us.Visible = true;
            btn_close_us.Visible = false;
            btn_previous_us.Visible = false;
            btn_next_us.Visible = false;
            cmb_username_us.Visible = false;
            cmb_role_us.Visible = true;
            txb_username_us.Visible = true;
            txb_role_us.Enabled = false;
            txb_name_us.ReadOnly = false;
            txb_firstname_us.ReadOnly = false;
            txb_username_us.ReadOnly = false;
            txb_password_us.ReadOnly = false;
            lbl_password_minlength_us.Visible = true;
            AcceptButton = btn_confirm_us; // Définit le bouton par défaut pour la confirmation
        }

        // Désactive le mode édition des champs de texte et des boutons
        private void DeactivateEditMode()
        {
            btn_add_us.Visible = true;
            btn_delete_us.Visible = true;
            btn_modify_us.Visible = true;
            btn_confirm_us.Visible = false;
            btn_cancel_us.Visible = false;
            btn_close_us.Visible = true;
            btn_previous_us.Visible = true;
            btn_next_us.Visible = true;
            cmb_username_us.Visible = true;
            cmb_role_us.Visible = false;
            txb_username_us.Visible = false;
            txb_role_us.Enabled = true;
            txb_name_us.ReadOnly = true;
            txb_firstname_us.ReadOnly = true;
            txb_username_us.ReadOnly = true;
            txb_password_us.ReadOnly = true;
            lbl_password_minlength_us.Visible = false;
            AcceptButton = btn_close_us; // Définit le bouton par défaut pour la fermeture
        }
    }
}
