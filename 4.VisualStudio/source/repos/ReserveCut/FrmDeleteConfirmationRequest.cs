using ReserveCut.Classes;

namespace ReserveCut
{
    // Classe représentant un formulaire de demande de confirmation de suppression
    public partial class FrmDeleteConfirmationRequest : Form
    {
        private Button callbtndel; // Bouton qui a déclenché la demande de suppression
        private FrmReserveCut frmReserveCut; // Instance du formulaire principal
        private FrmReservation frmReservation; // Instance du formulaire de réservation

        // Constructeur de la classe FrmDeleteConfirmationRequest
        public FrmDeleteConfirmationRequest(Button callingButton, FrmReserveCut frmReserveCut, FrmReservation frmReservation)
        {
            InitializeComponent(); // Initialise les composants du formulaire
            callbtndel = callingButton; // Initialise le bouton appelant
            this.frmReserveCut = frmReserveCut; // Initialise le formulaire principal
            this.frmReservation = frmReservation; // Initialise le formulaire de réservation
        }

        // Méthode déclenchée lors de l'affichage initial du formulaire de demande de confirmation de suppression
        private void deleteConfirmationFom_Shown(object sender, EventArgs e)
        {
            btn_cancel_dcr.Focus(); // Donne le focus au bouton "Annuler" pour que l'utilisateur puisse facilement appuyer sur "Entrée" pour annuler
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Confirmer"
        private async void btn_confirm_dcr_Click(object sender, EventArgs e)
        {
            FrmDeleteConfirmation frmDeleteConfirmation = new FrmDeleteConfirmation(); // Crée une nouvelle instance du formulaire de confirmation de suppression
            switch (callbtndel.Name) // Vérifie quel bouton a déclenché la demande
            {
                case "btn_delete_re":
                    bool isDeletedReservation = await Request.DeleteReservationAsync(LocalStorage.selectedReservation);
                    if (isDeletedReservation)
                    {
                        await frmReserveCut.LoadReservations(); // Recharge les réservations
                        frmReserveCut.UpdateReservationUI(); // Met à jour l'interface utilisateur des réservations
                        frmDeleteConfirmation.ShowDialog(); // Affiche le formulaire de confirmation de suppression
                        this.Close(); // Ferme le formulaire de demande de confirmation de suppression
                        frmReservation.Close(); // Ferme le formulaire de réservation
                    }
                    break;
                case "btn_delete_rc":
                    break;
                case "btn_delete_rs":
                    break;
                case "btn_delete_rh":
                    break;
                case "btn_delete_us":
                    Console.WriteLine(LocalStorage.selectedUser.name); // Affiche le nom de l'utilisateur sélectionné
                    Console.WriteLine(LocalStorage.selectedUser.id); // Affiche l'identifiant de l'utilisateur sélectionné
                    bool isDeletedUser = await Request.DeleteUserAsync(LocalStorage.selectedUser);
                    if (isDeletedUser)
                    {
                        LocalStorage.users.Remove(LocalStorage.selectedUser); // Met à jour la liste locale des utilisateurs
                        frmDeleteConfirmation.ShowDialog(); // Affiche le formulaire de confirmation de suppression
                        this.Close(); // Ferme le formulaire de demande de confirmation de suppression
                    }
                    break;
                default:
                    break;
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Annuler"
        private void btn_cancel_dcr_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de demande de confirmation de suppression
        }

        // Méthode déclenchée lors du chargement initial du formulaire de demande de confirmation de suppression
        private void FrmDeleteConfirmationRequest_Load(object sender, EventArgs e)
        {
            btn_cancel_dcr.Focus(); // Donne le focus au bouton "Annuler" pour que l'utilisateur puisse facilement appuyer sur "Entrée" pour annuler
        }
    }
}
