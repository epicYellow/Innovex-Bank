﻿
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

        public ClientRestService _clientRestService;

        public AccountRestService _accountRestService;
        public ObservableCollection<Accounts> AllAccounts { get; set; }
        public ObservableCollection<Transactions> AllTransactions { get; set; }
        public ObservableCollection<AccountTypes> AllAccountTypes { get; set; }

        //All clients for add account dropdown
        public ObservableCollection<Client> AllClients { get; set; }

        public string Account_number { get; set; }
        public string Type_id { get; set; }
        public int Account_Id { get; set; }
        public string IdError { get; set; }

        //Add account vars
        public string ClientError { get; set; }
        public string AccountTypeError { get; set; }
        public Client ClientSelection { get; set; }
        public AccountTypes TypeSelection { get; set; }
        public int TotalTaxFreeAccounts { get; set; }
        public int TotalDiamondAccounts { get; set; }
        public int TotalEasyAccessSavings { get; set; }
        public int TotalGoldCheque { get; set; }
        public ICommand AddAccount { get; private set; }
        int randomAccountNumber;
        private readonly Random _random = new Random();

        //Account Management Page
        public ObservableCollection<Transactions> SelectedTransactions { get; set; }
        //Side Column bindings
        public string AccountHolderName { get; set; } = "AccountHolder Name";

        //remove void and add rest return type
        public AccountManageViewModel(TransactionRestService restService, ClientRestService clientRest, AccountRestService accountRestService)
        {
            _transactionRest = restService;
            _clientRestService = clientRest;
            _accountRestService = accountRestService;

            AllAccounts = new ObservableCollection<Accounts>();

            AllTransactions = new ObservableCollection<Transactions>();

            AllAccountTypes = new ObservableCollection<AccountTypes>();

            AllClients = new ObservableCollection<Client>(); // Initialize here

            SelectedTransactions = new ObservableCollection<Transactions>();

            AddAccount = new Command(async () => await AddNewAccount());
        }

        private async Task AddNewAccount()
        {
            Debug.WriteLine("addaccount");
            randomAccountNumber = _random.Next(10000000, 100000000);

            Debug.WriteLine(TypeSelection);
            if(ClientSelection == null)
            {
                ClientError = "Please select a Client";
            }
            if(TypeSelection == null)
            {
                AccountTypeError = "Please select an Account Type";
            }

            OnPropertyChanged(nameof(ClientError));
            OnPropertyChanged(nameof(AccountTypeError));

            if (ClientSelection != null && TypeSelection != null)
            {
                var newAccount = new Accounts
                {
                    Account_number = randomAccountNumber.ToString(),
                    Type_id = TypeSelection.Id,
                    Transaction_fee = TypeSelection.Transaction_fee,
                    Balance = 0,
                    Free_transactions_left = TypeSelection.Free_limit,
                    Client_id = ClientSelection.Id,
                    Client_name = ClientSelection.First_name + " " + ClientSelection.Last_name,
                };

                    await _accountRestService.SaveAccountAsync(newAccount, true);
                    await Shell.Current.GoToAsync("..");
            }

            await updateCounts();
        }

        public async Task GetTransactionsById(int Id, string name)
        {

            IdError = string.Empty;
            SelectedTransactions.Clear();
            var Items = await _transactionRest.RetrieveTransactionsById(Id);
            if(Items == null || Items.Count == 0)
            {
                IdError = "No transactions found";
            } else
            {
                foreach (var transaction in Items)
                {
                    SelectedTransactions.Add(transaction);
                }
            }

            AccountHolderName = name;


            OnPropertyChanged(nameof(SelectedTransactions));
            OnPropertyChanged(nameof(AccountHolderName));
            OnPropertyChanged(nameof(IdError));
        }

        public async Task updateCounts()
        {

            var Items = await _transactionRest.RefreshAccountsync();

            TotalTaxFreeAccounts = Items.Where(c => c.Type_id == 3).ToList().Count();
            TotalDiamondAccounts = Items.Where(c => c.Type_id == 2).ToList().Count();
            TotalEasyAccessSavings = Items.Where(c => c.Type_id == 4).ToList().Count();
            TotalGoldCheque = Items.Where(c => c.Type_id == 1).ToList().Count();

            OnPropertyChanged(nameof(TotalTaxFreeAccounts));
            OnPropertyChanged(nameof(TotalDiamondAccounts));
            OnPropertyChanged(nameof(TotalEasyAccessSavings));
            OnPropertyChanged(nameof(TotalGoldCheque));
        }

        public async Task getAllAccounts()
        {
            //uncomment and implement
            var Items = await _transactionRest.RefreshAccountsync();
            AllAccounts.Clear();

            await updateCounts();

            foreach (var account in Items)
            {
                AllAccounts.Add(account);
                Debug.WriteLine(account);
            }
        }

        public async Task getAllAccountTypes()
        {
            //uncomment and implement
            var Items = await _accountRestService.RefreshAccountTypeAsync();
            AllAccounts.Clear();
            foreach (var account in Items)
            {
                AllAccountTypes.Add(account);
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
            }
        }

        public async Task getAllClients()
        {
            var Items = await _clientRestService.RefreshClientAsync();
            AllClients.Clear();
            foreach (var client in Items)
            {
                AllClients.Add(client);
            }
        }
    }
}
