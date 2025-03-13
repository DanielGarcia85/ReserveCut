using ReserveCut.Classes;

namespace ReserveCut
{
    // Classe représentant le formulaire pour ajouter une nouvelle réservation
    public partial class FrmNewReservation : Form
    {
        private FrmReserveCut frmReserveCut; // Référence au formulaire principal pour les réservations

        // Constructeur de la classe FrmNewReservation
        public FrmNewReservation(FrmReserveCut frmReserveCut)
        {
            InitializeComponent(); // Initialise les composants du formulaire
            // Définit le style des ComboBox pour qu'ils soient en mode liste déroulante
            cmb_time_nr.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_customer_nr.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_styliste_nr.DropDownStyle = ComboBoxStyle.DropDownList;
            this.frmReserveCut = frmReserveCut; // Initialise la référence au formulaire principal
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Annuler"
        private void btn_cancel_nr_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de nouvelle réservation
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton pour ajouter un nouveau client
        private void btn_addcustomer_nr_Click(object sender, EventArgs e)
        {
            FrmNewCustomer frmNewCustomer = new FrmNewCustomer(); // Crée une nouvelle instance du formulaire d'ajout de client
            frmNewCustomer.ShowDialog(); // Affiche le formulaire d'ajout de client en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "Ajouter"
        private async void btn_add_nr_Click(object sender, EventArgs e)
        {
            // Valide les entrées de la réservation
            if (!ValidateReservationInputs()) { return; }
            // Récupère les identifiants des clients et des coiffeurs sélectionnés
            var selectedCustomerId = ((Customer)cmb_customer_nr.SelectedItem).id;
            var selectedStylistId = ((Stylist)cmb_styliste_nr.SelectedItem).id;
            // Crée une nouvelle instance de réservation avec les détails fournis
            var reservation = new Reservation
            {
                customer = LocalStorage.customers.FirstOrDefault(c => c.id == selectedCustomerId),
                stylist = LocalStorage.stylists.FirstOrDefault(s => s.id == selectedStylistId),
                date_begin = dtp_reservationdate_nr.Value.Date.Add(TimeSpan.Parse(cmb_time_nr.Text)),
                date_end = dtp_reservationdate_nr.Value.Date.Add(TimeSpan.Parse(cmb_time_nr.Text)).AddMinutes(30),
                shampoo_y_n = rdo_yes_shampoo_nr.Checked,
                beard_y_n = rdo_yes_beard_nr.Checked,
                comments = txb_comments_nr.Text
            };
            // Ajoute la nouvelle réservation via une requête asynchrone
            bool isCreated = await Request.AddReservationAsync(reservation);
            if (isCreated)
            {
                await frmReserveCut.LoadReservations(); // Recharge les réservations
                frmReserveCut.UpdateReservationUI(); // Met à jour l'interface utilisateur des réservations
                FrmAddConfirmation frmAddConfirmation = new FrmAddConfirmation(); // Crée une nouvelle instance du formulaire de confirmation d'ajout
                frmAddConfirmation.ShowDialog(); // Affiche le formulaire de confirmation d'ajout en tant que boîte de dialogue modale
                // Réinitialise les champs du formulaire après l'ajout
                cmb_time_nr.SelectedIndex = -1;
                cmb_customer_nr.SelectedIndex = -1;
                cmb_styliste_nr.SelectedIndex = -1;
                rdo_yes_shampoo_nr.Checked = false;
                rdo_no_shampoo_nr.Checked = false;
                rdo_yes_beard_nr.Checked = false;
                rdo_no_beard_nr.Checked = false;
                rdo_yes_shampoo_nr.TabStop = true;
                rdo_no_shampoo_nr.TabStop = true;
                rdo_yes_beard_nr.TabStop = true;
                rdo_no_beard_nr.TabStop = true;
                txb_comments_nr.Text = "";
            }
        }

        // Valide les entrées de la réservation
        private bool ValidateReservationInputs()
        {
            if (!DateTime.TryParse(dtp_reservationdate_nr.Text, out _))
            {
                MessageBox.Show("Veuillez sélectionner une date valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmb_time_nr.Text) || !TimeSpan.TryParse(cmb_time_nr.Text, out _))
            {
                MessageBox.Show("Veuillez sélectionner une heure.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmb_customer_nr.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmb_styliste_nr.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un coiffeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // Méthode déclenchée lors du chargement initial du formulaire de nouvelle réservation
        private void FrmNewReservation_Load(object sender, EventArgs e)
        {
            LoadDataAsync(); // Charge les données asynchrones nécessaires au formulaire
            dtp_reservationdate_nr.Focus(); // Donne le focus au contrôle DateTimePicker pour la date de réservation
        }

        // Charge les données asynchrones nécessaires au formulaire
        private async Task LoadDataAsync()
        {
            var customers = LocalStorage.customers; // Récupère la liste des clients
            var stylists = LocalStorage.stylists; // Récupère la liste des coiffeurs
            // Configure les sources de données et les champs d'affichage des ComboBox
            cmb_customer_nr.DataSource = customers;
            cmb_customer_nr.DisplayMember = "fullName";
            cmb_customer_nr.ValueMember = "id";
            cmb_styliste_nr.DataSource = stylists;
            cmb_styliste_nr.DisplayMember = "fullName";
            cmb_styliste_nr.ValueMember = "id";
            // Réinitialise les sélections des ComboBox
            cmb_customer_nr.SelectedIndex = -1;
            cmb_styliste_nr.SelectedIndex = -1;
        }
    }
}
