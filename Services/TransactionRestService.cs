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
        internal string baseUrl = "https://localhost:7230/api/TransactionsModels";
      
        // List of Staff
        public List<Transactions> Items { get; private set; }

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
            Items = new List<Transactions>();

            Uri uri = new(string.Format(baseUrl, string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Transactions>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
