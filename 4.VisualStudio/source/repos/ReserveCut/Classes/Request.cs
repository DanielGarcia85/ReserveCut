using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;

namespace ReserveCut.Classes
{
    // Classe contenant les méthodes pour effectuer des requêtes HTTP vers l'API
    public class Request
    {
        // Récupère la liste des coiffeurs depuis l'API
        // Retourne une liste de coiffeur (List<Stylist>) si la requête est réussie, sinon retourne une liste vide
        public static async Task<List<Stylist>> GetStylistsAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                HttpResponseMessage response = await client.GetAsync("stylists");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var stylists = JsonConvert.DeserializeObject<List<Stylist>>(responseBody);
                    Console.WriteLine("Stylists loaded successfully from DB");
                    return stylists;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la récupération des coiffeurs \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Stylist>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Stylist>();
            }
        }

        // Récupère la liste des reservations depuis l'API
        // Retourne une liste de reservation (List<Reservation>) si la requête est réussie, sinon retourne une liste vide
        public static async Task<List<Reservation>> GetReservationsAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                HttpResponseMessage response = await client.GetAsync("reservations");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var reservations = JsonConvert.DeserializeObject<List<Reservation>>(responseBody);
                    Console.WriteLine("Reservations loaded successfully from DB");
                    return reservations;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la récupération des réservations \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Reservation>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Reservation>();
            }
        }

        // Récupère la liste des clients depuis l'API
        // Retourne une liste de client (List<Customer>) si la requête est réussie, sinon retourne une liste vide
        public static async Task<List<Customer>> GetCustomersAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                HttpResponseMessage response = await client.GetAsync("customers");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var customers = JsonConvert.DeserializeObject<List<Customer>>(responseBody);
                    Console.WriteLine("Customers loaded successfully from DB");
                    return customers;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la récupération des clients \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Customer>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Customer>();
            }
        }

        // Récupère la liste des coupes de cheveux depuis l'API
        // Retourne une liste de coupe de cheveux (List<Haircut>) si la requête est réussie, sinon retourne une liste vide
        public static async Task<List<Haircut>> GetHaircutsAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                HttpResponseMessage response = await client.GetAsync("haircuts");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var haircuts = JsonConvert.DeserializeObject<List<Haircut>>(responseBody);
                    Console.WriteLine("Haircuts loaded successfully from DB");
                    return haircuts;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la récupération des coupes de cheveux \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Haircut>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Haircut>();
            }
        }

        // Récupère la liste des des absences depuis l'API
        // Retourne une liste d'absence (List<Absence>) si la requête est réussie, sinon retourne une liste vide
        public static async Task<List<Absence>> GetAbsencesAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                HttpResponseMessage response = await client.GetAsync("absences");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var absences = JsonConvert.DeserializeObject<List<Absence>>(responseBody);
                    Console.WriteLine("Absences loaded successfully from DB");
                    return absences;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la récupération des absences \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<Absence>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Absence>();
            }
        }

        // Récupère la liste des des users depuis l'API
        // Retourne une liste de user (List<User>) si la requête est réussie, sinon retourne une liste vide
        public static async Task<List<User>> GetUsersAsync()
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                HttpResponseMessage response = await client.GetAsync("users");
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<List<User>>(responseBody);
                    Console.WriteLine("Users loaded successfully from DB");
                    return users;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la récupération des utilisateurs \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<User>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<User>();
            }
        }

        // Ajoute une nouvelle réservation via l'API
        // Retourne true si la réservation a été créée avec succès, sinon retourne false
        public static async Task<bool> AddReservationAsync(Reservation reservation)
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                string dateBeginString = LocalTools.ConvertDateFormat(reservation.date_begin);
                string dateEndString = LocalTools.ConvertDateFormat(reservation.date_end);
                var json = JsonConvert.SerializeObject(new
                {
                    customer_id = reservation.customer.id,
                    stylist_id = reservation.stylist.id,
                    date_begin = dateBeginString,
                    date_end = dateEndString,
                    comments = reservation.comments,
                    beard_y_n = reservation.beard_y_n,
                    shampoo_y_n = reservation.shampoo_y_n
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("reservations", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Reservation created successfully");
                    return true;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la création de la réservation \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Ajoute un nouvel utilisateur via l'API
        // Retourne true si l'utilisateur a été ajouté avec succès, sinon retourne false
        public static async Task<bool> AddUserAsync(User user)
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                var json = JsonConvert.SerializeObject(new
                {
                    name = user.name,
                    firstname = user.firstname,
                    username = user.username,
                    password = user.password,
                    role = user.role
                });
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("users", content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User added successfully");
                    return true;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de l'ajout de l'utilisateur \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Met à jour une réservation existante via l'API
        // Retourne true si la réservation a été mise à jour avec succès, sinon retourne false
        public static async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                var query = new StringBuilder();
                query.Append($"customer_id={reservation.customer.id}");
                query.Append($"&stylist_id={reservation.stylist.id}");
                string dateBeginString = LocalTools.ConvertDateFormat(reservation.date_begin);
                string dateEndString = LocalTools.ConvertDateFormat(reservation.date_end);
                query.Append($"&date_begin={dateBeginString}");
                query.Append($"&date_end={dateEndString}");
                query.Append($"&comments={reservation.comments}");
                query.Append($"&beard_y_n={(reservation.beard_y_n ? 1 : 0)}");
                query.Append($"&shampoo_y_n={(reservation.shampoo_y_n ? 1 : 0)}");
                HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), $"reservations/{reservation.id}?{query}");
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Reservation updated successfully");
                    return true;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la mise à jour de la réservation \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Met à jour un utilisateur existante via l'API
        // Retourne true si l'utilisateur a été mise à jour avec succès, sinon retourne false
        public static async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                var query = new StringBuilder();
                query.Append($"name={user.name}");
                query.Append($"&firstname={user.firstname}");
                query.Append($"&username={user.username}");
                query.Append($"&password={user.password}");
                query.Append($"&role={user.role}");
                HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), $"users/{user.id}?{query}");
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User updated successfully");
                    return true;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la mise à jour de l'utilisateur \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Supprime une réservation existante via l'API
        // Retourne true si la reservation a été supprimé avec succès, sinon retourne false
        public static async Task<bool> DeleteReservationAsync(Reservation reservation)
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                HttpResponseMessage response = await client.DeleteAsync($"reservations/{reservation.id}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Reservation deleted successfully");
                    return true;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la suppression de la réservation \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Supprime un utilisateur existante via l'API
        // Retourne true si l'utilisateur a été supprimé avec succès, sinon retourne false
        public static async Task<bool> DeleteUserAsync(User user)
        {
            try
            {
                using HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorage.token);
                HttpResponseMessage response = await client.DeleteAsync($"users/{user.id}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User deleted successfully");
                    return true;
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    string errorMessage = $"Erreur lors de la suppression de l'utilisateur \nCode {(int)response.StatusCode} ({response.StatusCode}) \n{errorBody}";
                    MessageBox.Show(errorMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
