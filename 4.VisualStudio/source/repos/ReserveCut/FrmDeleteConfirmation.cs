using System;

namespace ReserveCut
{
    // Classe représentant un formulaire de confirmation de suppression
    public partial class FrmDeleteConfirmation : Form
    {
        // Constructeur de la classe FrmDeleteConfirmation
        public FrmDeleteConfirmation()
        {
            InitializeComponent(); // Initialise les composants du formulaire, configurant ainsi l'interface utilisateur
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "OK"
        private void btn_ok_dc_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de confirmation de suppression
        }

        // Méthode déclenchée lors du chargement initial du formulaire
        private void FrmDeleteConfirmation_Load(object sender, EventArgs e)
        {
            btn_ok_dc.Focus(); // Donne le focus au bouton "OK" pour que l'utilisateur puisse facilement appuyer sur "Entrée" pour confirmer
        }
    }
}
