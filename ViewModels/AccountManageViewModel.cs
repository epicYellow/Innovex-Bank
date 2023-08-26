using CommunityToolkit.Mvvm.ComponentModel;
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
  
    class AccountManageViewModel : BaseViewModel
    {
        //add rests
        public RestService _rest;
        public ObservableCollection<Accounts> AllAccounts { get; set; }
        public ObservableCollection<Transactions> AllTransactions { get; set; }

        //remove void and add rest return type
        public AccountManageViewModel(RestService restService)
        {
            _rest = restService;
            AllAccounts = new ObservableCollection<Accounts>();
        }
        public void TransactionsViewModel()
        {
            AllTransactions = new ObservableCollection<Transactions>();
        }

        public async Task getAllAccounts()
        {
            //uncomment and implement
            var Items = await _rest.RefreshAccountsync();
            AllAccounts.Clear();
            foreach (var account in Items)
            {
                AllAccounts.Add(account);
                Debug.WriteLine(account);
            }
        }

        public async Task getAllTransactions()
        {
            //uncomment and implement
            //var Items = await _rest.RefreshDataAsync();
            AllTransactions.Clear();
            foreach (var transactions in AllTransactions)
            {
                AllTransactions.Add(transactions);
                Debug.WriteLine(transactions);
            }
        }
    }
}
