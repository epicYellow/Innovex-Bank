﻿using Innovex_Bank.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Innovex_Bank.Services
{
    internal class StaffService : IRestService
    {
        readonly HttpClient _client;
        readonly JsonSerializerOptions _serializerOptions;

        // Base API URL
        internal string baseUrl = "https://localhost:7230/api/";

        public List<Staff> StaffList { get; private set; }

        public StaffService()
        {
            _client = new HttpClient();

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task SaveStaffAsync(Staff item, bool isNewItem = false)
        {
            Uri uri = new(string.Format($"{baseUrl}Staff/", string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Staff>(item, _serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                    response = await _client.PostAsync(uri, content);
                else
                    response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\Staff member successfully saved.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task<List<Staff>> RefreshStaffAsync()
        {
            StaffList = new List<Staff>();

            Uri uri = new(string.Format($"{baseUrl}Staff/", string.Empty));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    StaffList = JsonSerializer.Deserialize<List<Staff>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return StaffList;
        }
    }
}
