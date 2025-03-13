using Newtonsoft.Json;
using ReserveCut.Classes;
using System.Net.Http.Headers;
using System.Text;

namespace ReserveCut
{
    // Classe représentant le formulaire de gestion des réservations
    public partial class FrmReservation : Form
    {
        private Reservation reservation; // Réservation en cours de modification
        private FrmReserveCut frmReserveCut; // Référence au formulaire principal pour les réservations

        // Constructeur de la classe FrmReservation
        public FrmReservation(Reservation reservation, FrmReserveCut frmReserveCut)
        {
            InitializeComponent(); // Initialise les composants du formulaire
            this.reservation = reservation; // Initialise la réservation avec l'objet passé en paramètre
            this.frmReserveCut = frmReserveCut; // Initialise la référence au formulaire principal
        }

        // Méthode déclenchée lors du chargement initial du formulaire de réservation
        private async void FrmReservation_Load(object sender, EventArgs e)
        {
            LoadReservationDetails(reservation); // Charge les détails de la réservation dans les champs du formulaire
            await LoadDataAsync(); // Charge les données nécessaires au formulaire de façon asynchrone
            dtp_date_re.Focus(); // Donne le focus au contrôle DateTimePicker pour la date de réservation
        }

        // Charge les détails de la réservation dans les champs du formulaire
        private void LoadReservationDetails(Reservation reservation)
        {
            LocalStorage.selectedReservation = reservation; // Définit la réservation sélectionnée pour suppression
            if (reservation != null)
            {
                // Remplit les champs avec les détails de la réservation
                txb_date_re.Text = reservation.date_begin.ToString("dd.MM.yyyy");
                txb_time_re.Text = reservation.date_begin.ToString("HH:mm");
                txb_customer_re.Text = reservation.customer.fullName;
                txb_stylist_re.Text = reservation.stylist.fullName;
                rdo_yes_shampoo_re.Checked = reservation.shampoo_y_n;
                rdo_no_shampoo_re.Checked = !reservation.shampoo_y_n;
                rdo_yes_beard_re.Checked = reservation.beard_y_n;
                rdo_no_beard_re.Checked = !reservation.beard_y_n;
                txb_comments_re.Text = reservation.comments;
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Modifier"
        private void btn_modify_re_Click(object sender, EventArgs e)
        {
            // Rend les contrôles de modification visibles et les champs en lecture seule invisibles
            dtp_date_re.Visible = true;
            cmb_time_re.Visible = true;
            cmb_customer_re.Visible = true;
            cmb_stylist_re.Visible = true;
            txb_date_re.Visible = false;
            txb_time_re.Visible = false;
            txb_customer_re.Visible = false;
            txb_stylist_re.Visible = false;
            txb_comments_re.ReadOnly = false;
            rdo_no_beard_re.Enabled = true;
            rdo_yes_beard_re.Enabled = true;
            rdo_no_shampoo_re.Enabled = true;
            rdo_yes_shampoo_re.Enabled = true;
            btn_modify_re.Visible = false;
            btn_delete_re.Visible = false;
            btn_close_re.Visible = false;
            btn_confirm_re.Visible = true;
            btn_cancel_re.Visible = true;
            AcceptButton = btn_confirm_re; // Définit le bouton par défaut pour la confirmation

            // Remplit les contrôles de modification avec les détails de la réservation
            dtp_date_re.Value = reservation.date_begin;
            cmb_time_re.Text = reservation.date_begin.ToString("HH:mm");
            cmb_customer_re.SelectedItem = reservation.customer;
            cmb_stylist_re.SelectedItem = reservation.stylist;
            rdo_yes_shampoo_re.Checked = reservation.shampoo_y_n;
            rdo_no_shampoo_re.Checked = !reservation.shampoo_y_n;
            rdo_yes_beard_re.Checked = reservation.beard_y_n;
            rdo_no_beard_re.Checked = !reservation.beard_y_n;
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Confirmer"
        private async void btn_confirm_re_Click(object sender, EventArgs e)
        {
            // Récupère les identifiants des clients et des coiffeurs sélectionnés
            int selectedCustomerId = ((Customer)cmb_customer_re.SelectedItem).id;
            int selectedStylistId = ((Stylist)cmb_stylist_re.SelectedItem).id;

            // Met à jour les détails de la réservation
            reservation.customer = LocalStorage.customers.FirstOrDefault(c => c.id == selectedCustomerId);
            reservation.stylist = LocalStorage.stylists.FirstOrDefault(s => s.id == selectedStylistId);
            DateTime date = dtp_date_re.Value.Date; // Récupère la date de la réservation
            TimeSpan time = TimeSpan.Parse(cmb_time_re.Text); // Récupère l'heure de la réservation
            DateTime dateBegin = date.Add(time);
            DateTime dateEnd = dateBegin.AddMinutes(30);
            reservation.date_begin = dateBegin;
            reservation.date_end = dateEnd;
            reservation.shampoo_y_n = rdo_yes_shampoo_re.Checked;
            reservation.beard_y_n = rdo_yes_beard_re.Checked;
            reservation.comments = txb_comments_re.Text;

            // Met à jour la réservation via une requête asynchrone
            bool isUpdated = await Request.UpdateReservationAsync(reservation);
            if (isUpdated)
            {
                // Rend les contrôles de modification invisibles et les champs en lecture seule visibles
                dtp_date_re.Visible = false;
                cmb_time_re.Visible = false;
                cmb_customer_re.Visible = false;
                cmb_stylist_re.Visible = false;
                txb_date_re.Visible = true;
                txb_time_re.Visible = true;
                txb_customer_re.Visible = true;
                txb_stylist_re.Visible = true;
                txb_comments_re.ReadOnly = true;
                rdo_no_beard_re.Enabled = false;
                rdo_yes_beard_re.Enabled = false;
                rdo_no_shampoo_re.Enabled = false;
                rdo_yes_shampoo_re.Enabled = false;
                btn_modify_re.Visible = true;
                btn_delete_re.Visible = true;
                btn_close_re.Visible = true;
                btn_confirm_re.Visible = false;
                btn_cancel_re.Visible = false;

                // Met à jour les champs en lecture seule avec les nouveaux détails de la réservation
                txb_date_re.Text = dtp_date_re.Text;
                txb_time_re.Text = cmb_time_re.Text;
                txb_customer_re.Text = cmb_customer_re.Text;
                txb_stylist_re.Text = cmb_stylist_re.Text;

                await frmReserveCut.LoadReservations(); // Recharge les réservations
                frmReserveCut.UpdateReservationUI(); // Met à jour l'interface utilisateur des réservations

                // Affiche le formulaire de confirmation de modification en tant que boîte de dialogue modale
                FrmModificationConfirmation frmModificationConfirmation = new FrmModificationConfirmation();
                frmModificationConfirmation.ShowDialog();
                AcceptButton = btn_close_re; // Définit le bouton par défaut pour la fermeture
            }
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Annuler"
        private void btn_cancel_re_Click(object sender, EventArgs e)
        {
            // Rend les contrôles de modification invisibles et les champs en lecture seule visibles
            dtp_date_re.Visible = false;
            cmb_time_re.Visible = false;
            cmb_customer_re.Visible = false;
            cmb_stylist_re.Visible = false;
            txb_date_re.Visible = true;
            txb_time_re.Visible = true;
            txb_customer_re.Visible = true;
            txb_stylist_re.Visible = true;
            txb_comments_re.ReadOnly = true;
            rdo_no_beard_re.Enabled = false;
            rdo_yes_beard_re.Enabled = false;
            rdo_no_shampoo_re.Enabled = false;
            rdo_yes_shampoo_re.Enabled = false;
            btn_modify_re.Visible = true;
            btn_delete_re.Visible = true;
            btn_close_re.Visible = true;
            btn_confirm_re.Visible = false;
            btn_cancel_re.Visible = false;

            // Réinitialise les champs en lecture seule avec les détails actuels de la réservation
            txb_date_re.Text = reservation.date_begin.ToString("dd.MM.yyyy");
            txb_time_re.Text = reservation.date_begin.ToString("HH:mm");
            txb_customer_re.Text = reservation.customer.name;
            txb_stylist_re.Text = reservation.stylist.name;
            txb_comments_re.Text = reservation.comments;
            rdo_yes_shampoo_re.Checked = reservation.shampoo_y_n;
            rdo_no_shampoo_re.Checked = !reservation.shampoo_y_n;
            rdo_yes_beard_re.Checked = reservation.beard_y_n;
            rdo_no_beard_re.Checked = !reservation.beard_y_n;
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Fermer"
        private async void btn_close_re_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de réservation
        }

        // Charge les données nécessaires au formulaire de façon asynchrone
        private async Task LoadDataAsync()
        {
            var customers = LocalStorage.customers; // Récupère la liste des clients
            var stylists = LocalStorage.stylists; // Récupère la liste des coiffeurs
            cmb_customer_re.DataSource = customers; // Définit la source de données pour le ComboBox des clients
            cmb_customer_re.DisplayMember = "fullName"; // Définit le champ à afficher pour les clients
            cmb_customer_re.ValueMember = "id"; // Définit la valeur associée à chaque client
            cmb_stylist_re.DataSource = stylists; // Définit la source de données pour le ComboBox des coiffeurs
            cmb_stylist_re.DisplayMember = "fullName"; // Définit le champ à afficher pour les coiffeurs
            cmb_stylist_re.ValueMember = "id"; // Définit la valeur associée à chaque coiffeur
            //cmb_customer_re.SelectedIndex = reservation.customer.id - 1; cmb_stylist_re.SelectedIndex = reservation.stylist.id - 1;
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Supprimer"
        private void btn_delete_re_Click(object sender, EventArgs e)
        {
            // Crée une nouvelle instance du formulaire de confirmation de suppression
            FrmDeleteConfirmationRequest frmDeleteConfirmation = new FrmDeleteConfirmationRequest(btn_delete_re, frmReserveCut, this);
            frmDeleteConfirmation.ShowDialog(); // Affiche le formulaire de confirmation de suppression en tant que boîte de dialogue modale
        }
    }
}
