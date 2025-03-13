using System;

namespace ReserveCut
{
    // Classe représentant un formulaire de confirmation d'ajout
    public partial class FrmAddConfirmation : Form
    {
        // Constructeur de la classe FrmAddConfirmation
        public FrmAddConfirmation()
        {
            InitializeComponent(); // Initialise les composants du formulaire, ce qui configure l'interface utilisateur
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton "OK"
        private void btn_ok_ac_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme le formulaire de confirmation d'ajout
        }

        // Méthode déclenchée lors du chargement initial du formulaire
        private void FrmAddConfirmation_Load(object sender, EventArgs e)
        {
            btn_ok_ac.Focus(); // Donne le focus au bouton "OK" pour que l'utilisateur puisse facilement appuyer sur "Entrée" pour confirmer
        }
    }
}
