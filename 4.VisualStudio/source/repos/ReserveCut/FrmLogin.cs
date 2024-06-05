using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using ReserveCut.Classes;

namespace ReserveCut
{
    // Classe représentant le formulaire de connexion
    public partial class FrmLogin : Form
    {
        // Constructeur de la classe FrmLogin
        public FrmLogin()
        {
            InitializeComponent(); // Initialise les composants du formulaire
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton de connexion
        private async void btn_login_lo_Click(object sender, EventArgs e)
        {
            try
            {
                using HttpClient client = new HttpClient(); // Crée une nouvelle instance de HttpClient
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/login"); // Définit l'adresse de base de l'API
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Définit le type de contenu accepté

                // Envoie une requête POST asynchrone avec les informations de connexion
                var response = await client.PostAsJsonAsync("login", new
                {
                    username = txb_username_lo.Text, // Nom d'utilisateur entré par l'utilisateur
                    password = txb_password_lo.Text  // Mot de passe entré par l'utilisateur
                });

                // Vérifie si la réponse de l'API est réussie
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync(); // Lit le contenu de la réponse
                    var res = JsonConvert.DeserializeObject<AccessToken>(responseBody); // Désérialise le contenu de la réponse en objet AccessToken
                    LocalStorage.token = res.token; // Stocke le token d'accès dans le stockage local
                    LocalStorage.loggedUserRole = res.user.role; // Stocke le rôle de l'utilisateur connecté dans le stockage local
                    this.Close(); // Ferme le formulaire de connexion
                    this.DialogResult = DialogResult.OK; // Définit le résultat du dialogue comme OK
                }
                else
                {
                    ShowLoginError(); // Affiche une erreur de connexion
                }
            }
            catch (HttpRequestException ex)
            {
                // Affiche un message d'erreur en cas de problème de connexion à l'API
                MessageBox.Show($"Une erreur de connexion à la base de donnée est survenue :\n{ex.Message}", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetLoginFields(); // Réinitialise les champs de connexion
            }
            catch (Exception ex)
            {
                // Affiche un message d'erreur pour toute autre exception
                MessageBox.Show($"Une erreur est survenue :\n{ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetLoginFields(); // Réinitialise les champs de connexion
            }
        }

        // Affiche un message d'erreur de connexion
        private void ShowLoginError()
        {
            FrmLoginError frmLoginError = new FrmLoginError(); // Crée une nouvelle instance du formulaire d'erreur de connexion
            frmLoginError.ShowDialog(); // Affiche le formulaire d'erreur de connexion
            ResetLoginFields(); // Réinitialise les champs de connexion
        }

        // Réinitialise les champs de connexion
        private void ResetLoginFields()
        {
            txb_username_lo.Text = ""; // Vide le champ du nom d'utilisateur
            txb_password_lo.Text = ""; // Vide le champ du mot de passe
            txb_username_lo.Focus(); // Donne le focus au champ du nom d'utilisateur
        }

        // Méthode déclenchée lorsque l'utilisateur clique sur le bouton d'annulation
        private void bnt_cancel_lo_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Ferme l'application
        }

        // Méthode déclenchée lors du chargement initial du formulaire de connexion
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txb_username_lo.Focus(); // Donne le focus au champ du nom d'utilisateur
        }
    }
}
