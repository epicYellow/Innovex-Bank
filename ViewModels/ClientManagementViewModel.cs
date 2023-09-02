using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Innovex_Bank.ViewModels
{
    class ClientManagementViewModel : BaseViewModel
    {
        //add rests
        public ClientRestService _rest;
        public ObservableCollection<Client> AllClients { get; set; }
        public string First_name { get; set; } = string.Empty;
        public string Last_name { get; set; } = string.Empty;
        public string Id_number { get; set; } = string.Empty;
        public string Phone_number { get; set; } = string.Empty;
        public string Address { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Date_of_birth { get; set; } = string.Empty;
        public bool Employment_status { get; set; }
        public int Monthly_income { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public ICommand AddNewClientCommand { get; }

        //remove void and add rest return type
        public ClientManagementViewModel(ClientRestService restService)
        {
            _rest = restService;
            AllClients = new ObservableCollection<Client>();

            AddNewClientCommand = new Command(async () => await AddClient());
        }

        private async Task AddClient()
        {
            Debug.WriteLine("lol");

            if (First_name == string.Empty || Last_name == string.Empty || Id_number == string.Empty || Phone_number == string.Empty || Address == string.Empty ||
                Gender == string.Empty || Email == string.Empty || Date_of_birth == string.Empty )
            {
                ErrorMessage = "Please fill in all the fields";
            } else
            {
                var newClient = new Client
                {
                    First_name = First_name,
                    Last_name = Last_name,
                    Id_number = Id_number,
                    Date_of_birth = Date_of_birth,
                    Gender = Gender,
                    Address = Address,
                    Email = Email,
                    Phone_number = Phone_number,
                    Employment_status = Employment_status,
                    Monthly_income = Monthly_income,
                };

                await _rest.SaveClientAsync(newClient, true);
                await Shell.Current.GoToAsync("..");
            }
        }

        public async Task getAllClients()
        {
            var Items = await _rest.RefreshClientAsync();
            AllClients.Clear();
            foreach (var clients in Items)
            {
                AllClients.Add(clients);
                Debug.WriteLine(clients);
            }
        }

        
    }
}
