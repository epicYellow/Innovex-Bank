using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.ViewModels
{
    class ClientManagementViewModel : BaseViewModel
    {
        //add rests
        public RestService _rest;
        public ObservableCollection<Client> AllClients { get; set; }

        //remove void and add rest return type
        public ClientManagementViewModel(RestService restService)
        {
            _rest = restService;
            AllClients = new ObservableCollection<Client>();
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
