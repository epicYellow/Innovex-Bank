using Innovex_Bank.Models;
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
        public ObservableCollection<Client> AllClients { get; set; }

        //remove void and add rest return type
        public void AccountsViewModel()
        {
            AllClients = new ObservableCollection<Client>();
        }

        public async Task getAllTransactions()
        {
            //uncomment and implement
            //var Items = await _rest.RefreshDataAsync();
            AllClients.Clear();
            foreach (var transactions in AllClients)
            {
                AllClients.Add(transactions);
                Debug.WriteLine(transactions);
            }
        }
    }
}
