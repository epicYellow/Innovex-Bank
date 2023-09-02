using Innovex_Bank.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Innovex_Bank.Services
{
    public class AccountRestService : IRestAccountService
    {
        readonly HttpClient _client;
        readonly JsonSerializerOptions _serializerOptions;

        // Base API URL
        internal string baseUrl = "https://localhost:7230/api/";

        public List<AccountTypes> AccountsTypes { get; private set; }

        public AccountRestService()
        {
            _client = new HttpClient();

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<AccountTypes>> RefreshAccountTypeAsync()
        {
            AccountsTypes = new List<AccountTypes>();

            Uri uri = new(string.Format($"{baseUrl}AccountTypes/", string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    AccountsTypes = JsonSerializer.Deserialize<List<AccountTypes>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return AccountsTypes;
        }

        public async Task SaveAccountAsync(Accounts item, bool isNewItem = false)
        {
            Uri uri = new(string.Format($"{baseUrl}Accounts/", string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Accounts>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                    response = await _client.PostAsync(uri, content);
                else
                    response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
