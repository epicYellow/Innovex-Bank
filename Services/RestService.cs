using System;
using System.Diagnostics;
using System.Text.Json;
using Innovex_Bank.Models;
using Microsoft.VisualBasic;

namespace Innovex_Bank.Services
{
	public class RestService : IRestService
	{
		// Define httpClient
		readonly HttpClient _client;
		readonly JsonSerializerOptions _serializerOptions;

		// Base API URL
		internal string baseUrl = "https://localhost:7230/api/";
		internal string clientsUrl = "https://localhost:7230/api/";

        // List of Staff
        public List<Staff> Items { get; private set; }
		public List<Client> Clients { get; private set; }

        // Creating httpClient
        public RestService()
		{
			_client = new HttpClient();

			_serializerOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true
			};
		}

        public async Task<List<Staff>> RefreshStaffAsync()
        {
            Items = new List<Staff>();

            Uri uri = new(string.Format($"{baseUrl}Staff/", string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Staff>>(content, _serializerOptions);
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

