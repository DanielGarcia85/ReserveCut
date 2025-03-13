using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReserveCut
{
    // Classe représentant un formulaire de chargement
    public partial class FrmLoading : Form
    {
        // Constructeur de la classe FrmLoading
        public FrmLoading()
        {
            InitializeComponent(); // Initialise les composants du formulaire

            // Définit l'image de chargement dans PictureBox
            pct_loading_rl.Image = Properties.Resources.loading;

            // Définit le formulaire pour qu'il soit toujours au premier plan
            this.TopMost = true;

            // Définit la position de démarrage du formulaire au centre de l'écran
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
