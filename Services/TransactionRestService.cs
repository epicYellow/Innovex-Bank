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
    internal class TransactionRestService : TransactionIRestService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        //base api url
        internal string baseUrl = "https://localhost:7230/api/";
      
        // List of Staff
        public List<Transactions> Transactions { get; private set; }
        public List<Accounts> Accounts { get; private set; }

        // Creating httpClient
        public TransactionRestService()
        {
            _client = new HttpClient();

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

        }

        public async Task<List<Transactions>> RefreshDataAsync()
        {
            Transactions = new List<Transactions>();

            Uri uri = new(string.Format($"{baseUrl}Transactions/"));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Transactions = JsonSerializer.Deserialize<List<Transactions>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Transactions;
        }

        public async Task<List<Transactions>> RetrieveTransactionsById(int id)
        {
            Transactions = new List<Transactions>();

            Uri uri = new(string.Format($"{baseUrl}Transactions/byId/{id}", string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Transactions = JsonSerializer.Deserialize<List<Transactions>>(content, _serializerOptions);
                } else if(response == null)
                {
                    Debug.WriteLine($"Recipe {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Transactions;
        }

        public async Task<List<Accounts>> RefreshAccountsync()
        {
            Accounts = new List<Accounts>();

            Uri uri = new(string.Format($"{baseUrl}Accounts", string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Accounts = JsonSerializer.Deserialize<List<Accounts>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Accounts;
        }


        public async Task<List<Accounts>> RetrieveAccountById(int id)
        {
            Accounts = new List<Accounts>();

            Uri uri = new(string.Format($"{baseUrl}Accounts/byId/{id}", string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Accounts = JsonSerializer.Deserialize<List<Accounts>>(content, _serializerOptions);
                }
                else if (response == null)
                {
                    Debug.WriteLine($"Account {id} not found.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Accounts;
        }
    }
}
