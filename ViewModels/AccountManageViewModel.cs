
using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

using System.Windows.Input;

namespace Innovex_Bank.ViewModels
{
  
    class AccountManageViewModel : BaseViewModel
    {
        public TransactionRestService _transactionRest;
        public ObservableCollection<Accounts> AllAccounts { get; set; }
        public ObservableCollection<Transactions> AllTransactions { get; set; }

        public string Account_number { get; set; }
        public string Type_id { get; set; }

        //Account Management Page
        public ObservableCollection<Transactions> SelectedTransactions { get; set; }
        //Side Column bindings
        public string AccountHolderName { get; set; } = string.Empty;
        public ICommand GetAccountTransactions { get; private set; }


        //remove void and add rest return type
        public AccountManageViewModel(TransactionRestService restService)
        {
            _transactionRest = restService;
            AllAccounts = new ObservableCollection<Accounts>();
            AllTransactions = new ObservableCollection<Transactions>();
            SelectedTransactions = new ObservableCollection<Transactions>();
            GetAccountTransactions = new Command(async () => await GetTransactionsById());
        }

        public async Task GetTransactionsById()
        {
            Debug.WriteLine("Running");
            var Items = await _transactionRest.RetrieveTransactionsById(1);
            SelectedTransactions.Clear();
            foreach (var transaction in Items)
            {
                SelectedTransactions.Add(transaction);
                Debug.WriteLine(transaction);
            }

            OnPropertyChanged(nameof(SelectedTransactions));
        }

        public async Task getAllAccounts()
        {
            //uncomment and implement
            var Items = await _transactionRest.RefreshAccountsync();
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
                Debug.WriteLine(transactions);
                AllTransactions.Add(transactions);
                Debug.WriteLine(transactions);
            }
        }
    }
}
