using Innovex_Bank.Models;
using Microsoft.Maui.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Innovex_Bank.Services
{
    public class AuthService
    {

        private const string AuthStateKey = "AuthState";

        // Define httpClient
        readonly HttpClient _client;
        readonly JsonSerializerOptions _serializerOptions;

        // Base API URL
        internal string baseUrl = "https://localhost:7230/api/";

        // Constructor
        public AuthService()
        {
            _client = new HttpClient();

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        // Check Authentication
        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(200);

            // Getting local storage state of the auth
            var authState = Preferences.Default.Get<bool>(AuthStateKey, false);

            return authState;
        }

        // Set Authenticated User
        public async Task<bool> LoginUser(Staff staff)
        {
            Uri uri = new(string.Format(baseUrl + "Auth/login", string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Staff>(staff, _serializerOptions);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage res = null;

                res = await _client.PostAsync(uri, content);

                if (res.IsSuccessStatusCode)
                {
                    Preferences.Default.Set<bool>(AuthStateKey, true);
                    Debug.WriteLine(@"\t AuthSuccessful");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tError {0}", ex.Message);
                return false;
            }
        }

        // Remove Authenticated user
        public void Logout()
        {
            Preferences.Default.Set<bool>(AuthStateKey, false);
        }

    }
}
