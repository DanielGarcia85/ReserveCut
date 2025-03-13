using ReserveCut.Classes;
using System;
using System.Windows.Forms;

namespace ReserveCut
{
    // Classe représentant le formulaire principal de l'application ReserveCut
    public partial class FrmReserveCut : Form
    {
        // Constructeur du formulaire principal
        public FrmReserveCut()
        {
            InitializeComponent();
            // Configuration de l'interface en fonction du rôle de l'utilisateur connecté
            if (LocalStorage.loggedUserRole == "user")
            {
                mns_file_rf.DropDownItems.Clear();
                mns_file_rf.DropDownItems.AddRange(new ToolStripItem[] { mns_new_rf, mns_quite_rf });
                mns_new_rf.DropDownItems.Clear();
                mns_new_rf.DropDownItems.AddRange(new ToolStripItem[] { msns_newreservation_rf, mns_newcustomer_rf });
                tab_reservecut_rf.Controls.Clear();
                tab_reservecut_rf.Controls.Add(tab_reservation_rr);
                tab_reservecut_rf.Controls.Add(tab_customer_rc);
            }
        }

        // Méthode déclenchée lors du chargement du formulaire principal
        private async void FrmReserveCut_Load(object sender, EventArgs e)
        {
            using (var loadingForm = new FrmLoading())
            {
                // Affiche le formulaire de chargement pour bloquer l'interaction utilisateur
                var task = Task.Run(() => loadingForm.ShowDialog());
                btn_add_rr.Focus();
                await LoadAndDisplayStylistsInCmb(); // Charge et affiche les coiffeurs dans le ComboBox
                await LoadReservations(); // Charge les réservations
                await LoadAndDisplayCustomers(); // Charge les clients
                await LoadHaircuts(); // Charge les coupes de cheveux
                await LoadAbsences(); // Charge les absences
                if (LocalStorage.loggedUserRole == "admin")
                {
                    await LoadUsers(); // Charge les utilisateurs si l'utilisateur connecté est un administrateur
                }
                LocalStorage.areReservationsLoaded = true;
                // Ferme le formulaire de chargement
                loadingForm.Invoke(new Action(() => loadingForm.Close()));
                await task; // S'assure que la tâche est bien attendue pour gérer correctement la fermeture du formulaire
            }
            cmb_stylist_rr.SelectedIndex = 0;
        }

        public async Task LoadAndDisplayCustomers()
        {
            await LoadCustomers(); // Charge les clients
            var customer = LocalStorage.customers.FirstOrDefault();
            if (customer == null)
            {
                txb_name_rc.Text = customer.name;
                txb_firstname_rc.Text += customer.firstname;
            }
        }

        // Charge et affiche les coiffeurs dans le ComboBox
        public async Task LoadAndDisplayStylistsInCmb()
        {
            await LoadStylists(); // Charge les coiffeurs
            var stylists = LocalStorage.stylists;
            cmb_stylist_rr.DataSource = stylists;
            cmb_stylist_rr.DisplayMember = "fullname";
            cmb_stylist_rr.ValueMember = "id";
            if (stylists.Any())
            {
                cmb_stylist_rr.SelectedIndex = -1;
            }
        }

        // Charge les réservations
        public async Task LoadReservations()
        {
            LocalStorage.reservations = await Request.GetReservationsAsync();
            Console.WriteLine("Nb reservation " + LocalStorage.reservations.Count());
        }

        // Charge les clients
        public async Task LoadCustomers()
        {
            LocalStorage.customers = await Request.GetCustomersAsync();
            Console.WriteLine("Nb customer " + LocalStorage.customers.Count());
        }

        // Charge les coiffeurs
        public async Task LoadStylists()
        {
            LocalStorage.stylists = await Request.GetStylistsAsync();
            Console.WriteLine("Nb stylist " + LocalStorage.stylists.Count());
        }

        // Charge les coupes de cheveux
        public async Task LoadHaircuts()
        {
            LocalStorage.haircuts = await Request.GetHaircutsAsync();
            Console.WriteLine("Nb haircut " + LocalStorage.haircuts.Count());
        }

        // Charge les absences
        public async Task LoadAbsences()
        {
            LocalStorage.absences = await Request.GetAbsencesAsync();
            Console.WriteLine("Nb absence " + LocalStorage.absences.Count());
        }

        // Charge les utilisateurs (administrateur uniquement)
        public async Task LoadUsers()
        {
            LocalStorage.users = await Request.GetUsersAsync();
            Console.WriteLine("Nb user " + LocalStorage.users.Count());
        }

        // Filtre les réservations en fonction du coiffeur sélectionné et de la semaine
        public void filterReservations()
        {
            // Trouve le début de la semaine (lundi)
            int diff = (7 + (LocalStorage.selectedStartDate.DayOfWeek - DayOfWeek.Monday)) % 7;
            DateTime startOfWeek = LocalStorage.selectedStartDate.AddDays(-1 * diff).Date;
            // Trouve la fin de la semaine (dimanche)
            DateTime endOfWeek = startOfWeek.AddDays(7).Date;
            LocalStorage.filteredReservations = LocalStorage.reservations.Where(r =>
                r.stylist.id == LocalStorage.selectedStylistId &&
                r.date_begin >= startOfWeek &&
                r.date_begin < endOfWeek)
                .ToList();

            Console.WriteLine("Nb reservation filtré " + LocalStorage.filteredReservations.Count());
        }

        // Met à jour l'interface utilisateur des réservations
        public void UpdateReservationUI()
        {
            filterReservations();
            var reservations = LocalStorage.filteredReservations;
            foreach (Control control in tab_reservation_rr.Controls)
            {
                if (control is Panel panel)
                {
                    panel.Controls.Clear();
                    panel.BackColor = Color.MintCream;
                    panel.Tag = null;
                    panel.Paint -= Panel_Paint; // Désabonner l'événement Paint
                    panel.Invalidate(); // Invalider le panel pour s'assurer qu'il est redessiné
                }
            }
            foreach (var reservation in reservations)
            {
                // Trouve le panel correspondant à la réservation
                string panelName = GetPanelName(reservation.date_begin);
                Panel panel = tab_reservation_rr.Controls.Find(panelName, true).FirstOrDefault() as Panel;
                if (panel != null)
                {
                    panel.Tag = reservation; // Stocker la réservation dans la propriété Tag du panel
                    panel.Paint += Panel_Paint; // Abonner l'événement Paint
                    panel.Invalidate(); // Invalider le panel pour déclencher l'événement Paint
                    panel.BackColor = Color.Linen;
                }
            }
        }

        // Méthode de dessin pour l'événement Paint
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel && panel.Tag is Reservation reservation)
            {
                // Définir la police et la couleur du texte
                Font font = new Font("Arial", 12);
                Brush brush = new SolidBrush(Color.Black);
                // Récupérer le nom du client
                string customerName = reservation.customer.name;
                // Calculer la position pour centrer le texte
                SizeF textSize = e.Graphics.MeasureString(customerName, font);
                PointF locationToDraw = new PointF
                {
                    X = (panel.Width / 2) - (textSize.Width / 2),
                    Y = (panel.Height / 2) - (textSize.Height / 2)
                };
                // Dessiner le texte
                e.Graphics.DrawString(customerName, font, brush, locationToDraw);
            }
        }

        // Génère le nom du panel basé sur la date et l'heure
        private string GetPanelName(DateTime dateTime)
        {
            string day = dateTime.DayOfWeek.ToString().Substring(0, 3).ToLower();
            string hour = dateTime.ToString("HHmm");
            return $"pnl_{hour}_{day}_rr";
        }

        // Méthode déclenchée lors de la sélection d'un coiffeur dans le ComboBox
        private void cmb_stylist_rr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!LocalStorage.areReservationsLoaded) return;
            var selectedStylist = cmb_stylist_rr.SelectedItem as Stylist;
            if (cmb_stylist_rr.SelectedItem != null)
            {
                int selectedId = selectedStylist.id;
                if (LocalStorage.selectedStylistId != selectedId)
                {
                    LocalStorage.selectedStylistId = selectedId;
                    Console.WriteLine($"Selected Stylist ID: {LocalStorage.selectedStylistId}");
                    UpdateReservationUI(); // Met à jour l'interface utilisateur des réservations
                    HighlightSelectedDayColumn(); // Surligne la colonne du jour sélectionné
                }
            }
        }

        // Méthode déclenchée lors du changement de date dans le DateTimePicker des réservations
        private void dtp_reservation_rr_ValueChanged(object sender, EventArgs e)
        {
            // Vérifie si la date sélectionnée est un dimanche
            if (dtp_reservation_rr.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("La sélection du dimanche n'est pas autorisée.", "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Réinitialise à la dernière date valide
                dtp_reservation_rr.Value = dtp_reservation_rr.Value.AddDays(1); // ou toute autre logique pour éviter le dimanche
            }
            else
            {
                LocalStorage.selectedStartDate = dtp_reservation_rr.Value;
                Console.WriteLine($"Selected Start Date: {LocalStorage.selectedStartDate}");
                UpdateReservationUI(); // Met à jour l'interface utilisateur des réservations
                HighlightSelectedDayColumn(); // Surligne la colonne du jour sélectionné
            }
        }

        // Surligne la colonne du jour sélectionné dans l'interface des réservations
        private void HighlightSelectedDayColumn()
        {
            // Réinitialise l'apparence de toutes les colonnes
            foreach (Control control in tab_reservation_rr.Controls)
            {
                if (control is Panel panel)
                {
                    panel.Paint -= Panel_PaintBorder;
                    panel.Invalidate(); // Déclenche la réinvalidation pour retirer les bordures précédentes
                }
            }
            // Détermine le jour de la semaine pour la date sélectionnée
            DayOfWeek selectedDay = LocalStorage.selectedStartDate.DayOfWeek;
            // Mappe le jour de la semaine à la colonne correspondante
            string dayColumn = selectedDay switch
            {
                DayOfWeek.Monday => "mon",
                DayOfWeek.Tuesday => "tue",
                DayOfWeek.Wednesday => "wed",
                DayOfWeek.Thursday => "thu",
                DayOfWeek.Friday => "fri",
                DayOfWeek.Saturday => "sat",
                DayOfWeek.Sunday => "sun",
            };
            // Surligne la colonne du jour sélectionné
            foreach (Control control in tab_reservation_rr.Controls)
            {
                if (control is Panel panel && panel.Name.Contains(dayColumn))
                {
                    panel.Paint += Panel_PaintBorder; // Abonne à l'événement Paint pour dessiner la bordure
                    panel.Invalidate(); // Déclenche la réinvalidation pour dessiner les nouvelles bordures
                }
            }
        }

        // Méthode de dessin pour l'événement Paint des bordures
        private void Panel_PaintBorder(object sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                using (Pen pen = new Pen(Color.LightSkyBlue, 3)) // Définit la couleur et la largeur de la bordure
                {
                    // Dessine les quatre côtés du rectangle pour rendre les bordures en gras
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        }

        // Méthode déclenchée lors du clic sur le menu "Utilisateurs"
        private void mns_users_rc_Click(object sender, EventArgs e)
        {
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.ShowDialog(); // Affiche le formulaire de gestion des utilisateurs en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le menu "Quitter"
        private void mns_quite_rc_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Quitte l'application
        }

        // Méthode déclenchée lors du clic sur le menu "Nouvelle réservation"
        private void mns_newreservation_rc_Click(object sender, EventArgs e)
        {
            FrmNewReservation frmNewReservation = new FrmNewReservation(this);
            frmNewReservation.ShowDialog(); // Affiche le formulaire de nouvelle réservation en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le menu "Nouveau client"
        private void mns_newcustomer_rc_Click(object sender, EventArgs e)
        {
            FrmNewCustomer frmNewCustomer = new FrmNewCustomer();
            frmNewCustomer.ShowDialog(); // Affiche le formulaire de nouveau client en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le menu "Nouveau coiffeur"
        private void mns_newstylist_rc_Click(object sender, EventArgs e)
        {
            FrmNewStylist frmNewStylist = new FrmNewStylist();
            frmNewStylist.ShowDialog(); // Affiche le formulaire de nouveau coiffeur en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le menu "Nouvelle coupe de cheveux"
        private void mns_newhaircut_rc_Click(object sender, EventArgs e)
        {
            FrmNewHaircut frmNewHaircut = new FrmNewHaircut();
            frmNewHaircut.ShowDialog(); // Affiche le formulaire de nouvelle coupe de cheveux en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter réservation"
        private void btn_add_rr_Click(object sender, EventArgs e)
        {
            FrmNewReservation frmNewReservation = new FrmNewReservation(this);
            frmNewReservation.ShowDialog(); // Affiche le formulaire de nouvelle réservation en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter client"
        private void btn_add_rc_Click(object sender, EventArgs e)
        {
            FrmNewCustomer frmNewCustomer = new FrmNewCustomer();
            frmNewCustomer.ShowDialog(); // Affiche le formulaire de nouveau client en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter coiffeur"
        private void btn_add_rs_Click(object sender, EventArgs e)
        {
            FrmNewStylist frmNewStylist = new FrmNewStylist();
            frmNewStylist.ShowDialog(); // Affiche le formulaire de nouveau coiffeur en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter coupe de cheveux"
        private void btn_add_rh_Click(object sender, EventArgs e)
        {
            FrmNewHaircut frmNewHaircut = new FrmNewHaircut();
            frmNewHaircut.ShowDialog(); // Affiche le formulaire de nouvelle coupe de cheveux en tant que boîte de dialogue modale
        }

        // Méthode déclenchée lors du clic sur le bouton "Modifier client"
        private void btn_modify_rc_Click(object sender, EventArgs e)
        {
            // Active le mode édition pour les informations du client
            mns_reservecut_rf.Enabled = false; tab_reservation_rr.Enabled = false; tab_stylist_rs.Enabled = false; tab_haircut_rh.Enabled = false;
            btn_add_rc.Visible = false; btn_delete_rc.Visible = false; btn_modify_rc.Visible = false; txb_search_rc.Enabled = false; txb_name_rc.ReadOnly = false;
            txb_firstname_rc.ReadOnly = false; txb_address_rc.ReadOnly = false; txb_city_rc.ReadOnly = false; txb_npa_rc.ReadOnly = false; txb_phone_rc.ReadOnly = false;
            txb_mail_rc.ReadOnly = false; txb_datebirth_rc.ReadOnly = false; txb_contact_rc.ReadOnly = false; txb_haircut_rc.ReadOnly = false;
            btn_confirm_rc.Visible = true; btn_cancel_rc.Visible = true; btn_previous_rc.Visible = false; btn_next_rc.Visible = false; btn_photo_rc.Visible = true;
            pic_customer_rc.Visible = false; cmb_haircut_rc.Visible = true; txb_haircut_rc.Visible = false; cmb_contact_rc.Visible = true; txb_contact_rc.Visible = false;
            dtp_birthdate_rc.Visible = true; txb_datebirth_rc.Visible = false;
            txb_search_rc.Text = "";
            txb_name_rc.Focus();
            AcceptButton = btn_cancel_rc;
            CancelButton = btn_cancel_rc;
        }
        // Méthode déclenchée lors du clic sur le bouton "Confirmer modification client"
        private void btn_confirm_rc_Click(object sender, EventArgs e)
        {
            // Désactive le mode édition pour les informations du client
            mns_reservecut_rf.Enabled = true; tab_reservation_rr.Enabled = true; tab_stylist_rs.Enabled = true; tab_haircut_rh.Enabled = true;
            btn_add_rc.Visible = true; btn_delete_rc.Visible = true; btn_modify_rc.Visible = true;
            txb_search_rc.Enabled = true; txb_name_rc.ReadOnly = true; txb_firstname_rc.ReadOnly = true; txb_address_rc.ReadOnly = true; txb_city_rc.ReadOnly = true; 
            txb_npa_rc.ReadOnly = true; txb_phone_rc.ReadOnly = true; txb_mail_rc.ReadOnly = true; txb_datebirth_rc.ReadOnly = true; txb_contact_rc.ReadOnly = true; txb_haircut_rc.ReadOnly = true;
            btn_confirm_rc.Visible = false; btn_cancel_rc.Visible = false; btn_previous_rc.Visible = true; btn_next_rc.Visible = true; btn_photo_rc.Visible = false;
            pic_customer_rc.Visible = true; cmb_haircut_rc.Visible = false; txb_haircut_rc.Visible = true; cmb_contact_rc.Visible = false; dtp_birthdate_rc.Visible = false; txb_datebirth_rc.Visible = true;
            txb_name_rc.Text = ""; txb_firstname_rc.Text = ""; txb_address_rc.Text = ""; txb_city_rc.Text = ""; txb_npa_rc.Text = ""; txb_phone_rc.Text = ""; txb_mail_rc.Text = "";
            cmb_contact_rc.SelectedItem = null;
            cmb_haircut_rc.SelectedItem = null;
            AcceptButton = btn_add_rc;
            txb_search_rc.Focus();
            FrmModificationConfirmation frmModificationConfirmation = new FrmModificationConfirmation();
            frmModificationConfirmation.ShowDialog();
        }

        // Méthode déclenchée lors du clic sur le bouton "Annuler modification client"
        private void btn_cancel_rc_Click(object sender, EventArgs e)
        {
            // Annule les modifications et réactive les contrôles
            mns_reservecut_rf.Enabled = true; tab_reservation_rr.Enabled = true; tab_stylist_rs.Enabled = true; tab_haircut_rh.Enabled = true; btn_add_rc.Visible = true; btn_delete_rc.Visible = true; btn_modify_rc.Visible = true;
            txb_search_rc.Enabled = true; txb_name_rc.ReadOnly = true; txb_firstname_rc.ReadOnly = true; txb_address_rc.ReadOnly = true; txb_city_rc.ReadOnly = true; txb_npa_rc.ReadOnly = true;
            txb_phone_rc.ReadOnly = true; txb_mail_rc.ReadOnly = true; txb_datebirth_rc.ReadOnly = true; txb_contact_rc.ReadOnly = true; txb_haircut_rc.ReadOnly = true;
            btn_confirm_rc.Visible = false; btn_cancel_rc.Visible = false; btn_previous_rc.Visible = true; btn_next_rc.Visible = true; btn_photo_rc.Visible = false;
            pic_customer_rc.Visible = true; cmb_haircut_rc.Visible = false; txb_haircut_rc.Visible = true; cmb_contact_rc.Visible = false; txb_contact_rc.Visible = true; dtp_birthdate_rc.Visible = false; txb_datebirth_rc.Visible = true;
            txb_name_rc.Text = ""; txb_firstname_rc.Text = ""; txb_address_rc.Text = ""; txb_city_rc.Text = ""; txb_npa_rc.Text = ""; txb_phone_rc.Text = ""; txb_mail_rc.Text = "";
            cmb_contact_rc.SelectedItem = null; cmb_haircut_rc.SelectedItem = null;
            AcceptButton = btn_add_rc;
            txb_search_rc.Focus();
        }

        // Méthode déclenchée lors du clic sur le bouton "Modifier coiffeur"
        private void btn_modify_rs_Click(object sender, EventArgs e)
        {
            // Active le mode édition pour les informations du coiffeur
            mns_reservecut_rf.Enabled = false; tab_reservation_rr.Enabled = false; tab_customer_rc.Enabled = false; tab_haircut_rh.Enabled = false;cmb_speciality_rs.Visible = true;
            btn_addspeciality_rs.Visible = true; btn_deletespeciality_rs.Visible = true; btn_addabsence_rs.Visible = true; btn_deleteabsence_rs.Visible = true; btn_previous_rs.Visible = false; btn_next_rs.Visible = false;
            pic_stylist_rs.Visible = false; btn_confirm_rs.Visible = true; btn_add_rs.Visible = false; btn_delete_rs.Visible = false; btn_modify_rs.Visible = false; btn_cancel_rs.Visible = true; btn_photo_rs.Visible = true;
            txb_search_rs.Enabled = false; txb_name_rs.ReadOnly = false; txb_firstname_rs.ReadOnly = false; 
            txb_search_rs.Text = "";
            txb_name_rs.Focus();
            AcceptButton = btn_cancel_rs;
            CancelButton = btn_cancel_rs;
        }

        // Méthode déclenchée lors du clic sur le bouton "Confirmer modification coiffeur"
        private void btn_confirm_rs_Click(object sender, EventArgs e)
        {
            // Désactive le mode édition pour les informations du coiffeur
            mns_reservecut_rf.Enabled = true; tab_reservation_rr.Enabled = true; tab_customer_rc.Enabled = true; tab_haircut_rh.Enabled = true; cmb_speciality_rs.Visible = false;
            btn_addspeciality_rs.Visible = false; btn_deletespeciality_rs.Visible = false; btn_addabsence_rs.Visible = false; btn_deleteabsence_rs.Visible = false; btn_previous_rs.Visible = true; btn_next_rs.Visible = true;
            btn_confirm_rs.Visible = false; btn_cancel_rs.Visible = false; btn_add_rs.Visible = true; btn_delete_rs.Visible = true; btn_modify_rs.Visible = true; btn_photo_rs.Visible = false;
            pic_stylist_rs.Visible = true; txb_search_rs.Enabled = true; txb_name_rs.ReadOnly = true; txb_firstname_rs.ReadOnly = true;
            txb_name_rs.Text = ""; txb_firstname_rs.Text = "";
            cmb_speciality_rs.SelectedIndex = -1;
            lst_speciality_rs.Items.Clear(); lst_absence_rs.Items.Clear();
            AcceptButton = btn_add_rs;
            txb_search_rs.Focus();
            // Affiche le formulaire de confirmation de modification en tant que boîte de dialogue modale
            FrmModificationConfirmation frmModificationConfirmation = new FrmModificationConfirmation();
            frmModificationConfirmation.ShowDialog();
        }

        // Méthode déclenchée lors du clic sur le bouton "Annuler modification coiffeur"
        private void btn_cancel_rs_Click(object sender, EventArgs e)
        {
            // Annule les modifications et réactive les contrôles
            mns_reservecut_rf.Enabled = true; tab_reservation_rr.Enabled = true; tab_customer_rc.Enabled = true; tab_haircut_rh.Enabled = true;
            cmb_speciality_rs.Visible = false; btn_addspeciality_rs.Visible = false; btn_deletespeciality_rs.Visible = false; btn_addabsence_rs.Visible = false;
            btn_deleteabsence_rs.Visible = false; btn_previous_rs.Visible = true; btn_next_rs.Visible = true; btn_confirm_rs.Visible = false; btn_cancel_rs.Visible = false;
            btn_add_rs.Visible = true; btn_delete_rs.Visible = true; btn_modify_rs.Visible = true; btn_photo_rs.Visible = false;
            pic_stylist_rs.Visible = true; txb_search_rs.Enabled = true; txb_name_rs.ReadOnly = true; txb_firstname_rs.ReadOnly = true;
            txb_name_rs.Text = ""; txb_firstname_rs.Text = "";
            cmb_speciality_rs.SelectedIndex = -1;
            lst_speciality_rs.Items.Clear(); lst_absence_rs.Items.Clear();
            AcceptButton = btn_add_rs;
            txb_search_rs.Focus();
        }

        // Méthode déclenchée lors du clic sur le bouton "Modifier coupe de cheveux"
        private void btn_modify_rh_Click(object sender, EventArgs e)
        {
            // Active le mode édition pour les informations de la coupe de cheveux
            mns_reservecut_rf.Enabled = false; tab_reservation_rr.Enabled = false; tab_customer_rc.Enabled = false; tab_stylist_rs.Enabled = false;
            txb_search_rh.Enabled = false; txb_name_rh.ReadOnly = false; txb_description_rh.ReadOnly = false; txb_cuttingtime_rh.ReadOnly = false; txb_shortlong_rh.Visible = false; txb_cuttingtime_rh.Visible = false;
            btn_previous_rh.Visible = false; btn_next_rh.Visible = false; cmb_shortlong_rh.Visible = true; cmb_cuttingtime_rh.Visible = true; txb_price_rh.ReadOnly = false;
            pic_haircut_rh.Visible = false; btn_photo_rh.Visible = true; btn_confirm_rh.Visible = true; btn_modify_rh.Visible = false; btn_add_rh.Visible = false; btn_delete_rh.Visible = false; btn_cancel_rh.Visible = true;
            txb_search_rh.Text = "";
            txb_name_rh.Focus();
            AcceptButton = btn_cancel_rh;
            CancelButton = btn_cancel_rh;
        }

        // Méthode déclenchée lors du clic sur le bouton "Confirmer modification coupe de cheveux"
        private void btn_confirm_rh_Click(object sender, EventArgs e)
        {
            // Désactive le mode édition pour les informations de la coupe de cheveux
            mns_reservecut_rf.Enabled = true; tab_reservation_rr.Enabled = true; tab_customer_rc.Enabled = true; tab_stylist_rs.Enabled = true;
            txb_search_rh.Enabled = true; txb_name_rh.ReadOnly = true; txb_description_rh.ReadOnly = true; txb_cuttingtime_rh.ReadOnly = true; txb_shortlong_rh.Visible = true; txb_cuttingtime_rh.Visible = true;
            btn_previous_rh.Visible = true; btn_next_rh.Visible = true; cmb_shortlong_rh.Visible = false; cmb_cuttingtime_rh.Visible = false; txb_price_rh.ReadOnly = true;
            pic_haircut_rh.Visible = true; btn_photo_rh.Visible = false; btn_add_rh.Visible = true; btn_modify_rh.Visible = true; btn_cancel_rh.Visible = false; btn_delete_rh.Visible = true; btn_confirm_rh.Visible = false;
            txb_name_rh.Text = ""; txb_description_rh.Text = ""; txb_cuttingtime_rh.Text = ""; txb_price_rh.Text = "";
            cmb_cuttingtime_rh.SelectedItem = null; cmb_shortlong_rh.SelectedItem = null;
            AcceptButton = btn_add_rh;
            txb_search_rh.Focus();
            // Affiche le formulaire de confirmation de modification en tant que boîte de dialogue modale
            FrmModificationConfirmation frmModificationConfirmation = new FrmModificationConfirmation();
            frmModificationConfirmation.ShowDialog();
        }

        // Méthode déclenchée lors du clic sur le bouton "Annuler modification coupe de cheveux"
        private void btn_cancel_rh_Click(object sender, EventArgs e)
        {
            // Annule les modifications et réactive les contrôles
            mns_reservecut_rf.Enabled = true; tab_reservation_rr.Enabled = true; tab_customer_rc.Enabled = true; tab_stylist_rs.Enabled = true;
            txb_search_rh.Enabled = true; txb_name_rh.ReadOnly = true; txb_description_rh.ReadOnly = true; txb_cuttingtime_rh.ReadOnly = true; txb_shortlong_rh.Visible = true; txb_cuttingtime_rh.Visible = true;
            btn_previous_rh.Visible = true; btn_next_rh.Visible = true; cmb_shortlong_rh.Visible = false; cmb_cuttingtime_rh.Visible = false; txb_price_rh.ReadOnly = true;
            pic_haircut_rh.Visible = true; btn_photo_rh.Visible = false; btn_add_rh.Visible = true; btn_modify_rh.Visible = true; btn_cancel_rh.Visible = false; btn_delete_rh.Visible = true; btn_confirm_rh.Visible = false;
            txb_name_rh.Text = ""; txb_description_rh.Text = ""; txb_cuttingtime_rh.Text = ""; txb_price_rh.Text = "";
            cmb_cuttingtime_rh.SelectedItem = null; cmb_shortlong_rh.SelectedItem = null;
            AcceptButton = btn_add_rh;
            txb_search_rh.Focus();
        }

        // Méthode déclenchée lors du clic sur le bouton "Supprimer client"
        private void btn_delete_rc_Click(object sender, EventArgs e)
        {
            // Affiche le formulaire de confirmation de suppression pour le client sélectionné
            FrmDeleteConfirmationRequest frmDeleteConfirmation = new FrmDeleteConfirmationRequest(btn_delete_rc, this, null);
            frmDeleteConfirmation.ShowDialog();
        }

        // Méthode déclenchée lors du clic sur le bouton "Supprimer coiffeur"
        private void btn_delete_rs_Click(object sender, EventArgs e)
        {
            // Affiche le formulaire de confirmation de suppression pour le coiffeur sélectionné
            FrmDeleteConfirmationRequest frmDeleteConfirmation = new FrmDeleteConfirmationRequest(btn_delete_rs, this, null);
            frmDeleteConfirmation.ShowDialog();
        }

        // Méthode déclenchée lors du clic sur le bouton "Supprimer coupe de cheveux"
        private void btn_delete_rh_Click(object sender, EventArgs e)
        {
            // Affiche le formulaire de confirmation de suppression pour la coupe de cheveux sélectionnée
            FrmDeleteConfirmationRequest frmDeleteConfirmation = new FrmDeleteConfirmationRequest(btn_delete_rh, this, null);
            frmDeleteConfirmation.ShowDialog();
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter photo client"
        private void btn_photo_rc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"; // Exemple de filtre
            openFileDialog.Title = "Sélectionnez un fichier";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Ici, vous pouvez faire ce que vous voulez avec le chemin du fichier sélectionné.
            }
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter photo coiffeur"
        private void btn_photo_rs_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"; // Exemple de filtre
            openFileDialog.Title = "Sélectionnez un fichier";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Ici, vous pouvez faire ce que vous voulez avec le chemin du fichier sélectionné.
            }
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter photo coupe de cheveux"
        private void btn_photo_rh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"; // Exemple de filtre
            openFileDialog.Title = "Sélectionnez un fichier";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Ici, vous pouvez faire ce que vous voulez avec le chemin du fichier sélectionné.
            }
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter spécialité coiffeur"
        private void btn_addspeciality_rs_Click(object sender, EventArgs e)
        {
            string speciality = cmb_speciality_rs.Text;
            if (!lst_speciality_rs.Items.Contains(speciality))
            {
                lst_speciality_rs.Items.Add(speciality);
            }
            else
            {
                MessageBox.Show($"{speciality} est déjà ajouté.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Méthode déclenchée lors du changement d'onglet
        private void tab_reservecut_rc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_reservecut_rf.SelectedIndex == 0) { btn_add_rr.Focus(); AcceptButton = btn_add_rr; }
            else if (tab_reservecut_rf.SelectedIndex == 1) { txb_search_rc.Focus(); AcceptButton = btn_add_rc; }
            else if (tab_reservecut_rf.SelectedIndex == 2) { txb_search_rs.Focus(); AcceptButton = btn_add_rs; }
            else if (tab_reservecut_rf.SelectedIndex == 3) { txb_search_rh.Focus(); AcceptButton = btn_add_rh; }
        }

        // Méthode déclenchée lors du clic sur le bouton "Ajouter absence coiffeur"
        private void btn_addabsence_rs_Click(object sender, EventArgs e)
        {
            FrmNewAbsence frmNewAbsence = new FrmNewAbsence();
            frmNewAbsence.ShowDialog();
        }

        // Ci-dessous toutes les méthode lorsqu'on double clique sur un pannel de "l'agenda"
        // Si un panel a une reservation (couleur rouge), alors le frm de la reservation en question est ouvert

        private void pnl_0800_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0830_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0900_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0930_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1000_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1030_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1100_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1130_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1200_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1230_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1300_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1330_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1400_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1430_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1500_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1530_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1600_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1630_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1700_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1730_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1800_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1830_mon_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0800_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0830_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0900_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0930_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1000_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1030_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1100_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1130_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1200_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1300_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1330_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1400_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1430_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1500_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1530_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1600_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1230_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1630_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1700_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1730_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1800_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1830_tue_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0800_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0830_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0900_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0930_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1000_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1030_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1100_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1130_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1200_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1230_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1300_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1330_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1400_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1430_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1500_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1530_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1600_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1630_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1700_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1730_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1800_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1830_wen_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0800_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            };
        }

        private void pnl_0830_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0900_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0930_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1000_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1030_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1100_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1130_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1200_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1230_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1300_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1330_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1400_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1430_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1500_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1530_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1600_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1630_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1700_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1730_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1800_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }

        }

        private void pnl_1830_thu_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0800_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0830_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0900_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0930_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1000_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1030_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1100_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1130_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1200_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1230_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1300_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1330_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1400_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1430_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1500_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1530_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1600_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1630_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1700_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1730_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1800_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1830_fri_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0800_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0830_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0900_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_0930_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1000_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1030_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1100_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1130_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1200_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1230_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1300_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1330_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1400_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1430_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1500_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1530_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1600_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1630_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1700_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }

        }

        private void pnl_1730_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1800_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }

        private void pnl_1830_sat_rr_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(sender is Panel panel && panel.BackColor == Color.Linen && panel.Tag is Reservation reservation)
            {
                FrmReservation frmReservation = new FrmReservation(reservation, this);
                frmReservation.ShowDialog();
            }
        }
        

    }
}
