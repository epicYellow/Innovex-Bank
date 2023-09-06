
using Innovex_Bank.ContentPages;
using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Security.Principal;
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
        public ObservableCollection<string> TransType { get; set; } = new ObservableCollection<string>() { "Withdrawal", "Deposit", "Transfer" };

        //All clients for add account dropdown
        public ObservableCollection<Client> AllClients { get; set; }
        public Accounts Ind_Account { get; set; }

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

        //Edit account page
        public int AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public AccountTypes NewAccountType { get; set; }
        public string First_name { get; set; }
        public float Balance { get; set; }

        public ICommand EditAccount { get; private set; }
        public ICommand TransactionCommand { get; private set; }

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
            EditAccount = new Command(async () => await updateAccount());
            TransactionCommand = new Command(async () => await MakeTransaction());
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

        public async Task updateEditValues(Accounts accountData)
        {
            Ind_Account = accountData;

            AccountType = accountData.Type_id;
            AccountName = accountData.Client_name;
            AccountNumber = accountData.Account_number;

            OnPropertyChanged(nameof(AccountType));
            OnPropertyChanged(nameof(AccountName));
            OnPropertyChanged(nameof(AccountNumber));
            OnPropertyChanged(nameof(Ind_Account));
        }

        public async Task updateTransValues(Accounts accountData)
        {
            Ind_Account = accountData;

            AccountType = accountData.Type_id;
            AccountName = accountData.Client_name;
            AccountNumber = accountData.Account_number;
            First_name = accountData.Client_name;
            Balance = accountData.Balance;

            OnPropertyChanged(nameof(AccountType));
            OnPropertyChanged(nameof(AccountName));
            OnPropertyChanged(nameof(AccountNumber));
            OnPropertyChanged(nameof(Ind_Account));
            OnPropertyChanged(nameof(Balance));
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

        public async Task updateAccount()
        {
            var updatedAccount = new Accounts
            {
                Id = Ind_Account.Id,
                Account_number = Ind_Account.Account_number,
                Type_id = NewAccountType.Id,
                Transaction_fee = NewAccountType.Transaction_fee,
                Balance = Ind_Account.Balance,
                Client_id = Ind_Account.Client_id,
                Free_transactions_left = NewAccountType.Free_limit,
                Client_name = Ind_Account.Client_name,
            };

            await _accountRestService.UpdateAccountAsync(updatedAccount, false);
            await Shell.Current.GoToAsync("..");
            await getAllAccounts();
        }

        public string SelectedItem { get; set; }
        public string ToFrom { get; set; } = "Select";
        public string AccountNumberEntry { get; set; }
        public int AmountEntry { get; set; }

        public async Task CheckFromTo()
        {
            if (SelectedItem == "Withdrawal")
            {
                ToFrom = "From";
            } else if (SelectedItem == "Deposit")
            {
                ToFrom = "Into";
            } else if (SelectedItem == "Transfer")
            {
                ToFrom = "To";
            }
            OnPropertyChanged(nameof(ToFrom));
        }
        private async Task MakeTransaction()
        {
            //new transaction
            //put account balance
            //transaction type
            if(ToFrom == "Select")
            {
                AccountTypeError = "Please select transaction type";
            }

            if(AccountNumberEntry == string.Empty || AmountEntry == 0)
            {
                AccountTypeError = "Enter required fields";
            }

            if(ToFrom != "Select" && AccountNumberEntry != string.Empty && AmountEntry != 0)
            {

                switch (SelectedItem)
                {
                    case "Withdrawal":
                        //Check that it is my account?
                        //Check if funds are available
                        //Make transaction
                        break;
                    case "Deposit":
                        // Get account by account number
                        // get all accounts
                        var accounts = await _transactionRest.RefreshAccountsync();

                        if (accounts != null)
                        {

                            Accounts targetAccount = accounts.FirstOrDefault(account => account.Account_number == AccountNumberEntry);
                            if(targetAccount != null)
                            {
                                Debug.WriteLine(targetAccount);
                                var target = new Accounts
                                {
                                    Id = targetAccount.Id,
                                    Account_number = targetAccount.Account_number,
                                    Type_id = targetAccount.Id,
                                    Transaction_fee = targetAccount.Transaction_fee,
                                    Balance = targetAccount.Balance + AmountEntry,
                                    Client_id = targetAccount.Client_id,
                                    Free_transactions_left = targetAccount.Free_transactions_left,
                                    Client_name = targetAccount.Client_name,
                                };

                                var From = new Accounts
                                {
                                    Id = Ind_Account.Id,
                                    Account_number = Ind_Account.Account_number,
                                    Type_id = Ind_Account.Id,
                                    Transaction_fee = Ind_Account.Transaction_fee,
                                    Balance = Ind_Account.Balance - AmountEntry,
                                    Client_id = Ind_Account.Client_id,
                                    Free_transactions_left = Ind_Account.Free_transactions_left - 1,
                                    Client_name = Ind_Account.Client_name,
                                };

                                var newTransaction = new Transactions
                                {
                                    Transaction_type = SelectedItem,
                                    Amount = AmountEntry,
                                    Date_and_time = DateTime.Now.ToString("M/d/yyyy"),
                                    Transaction_fee = Ind_Account.Transaction_fee,
                                    Account_Id = Ind_Account.Id
                                };

                                await _transactionRest.SaveTransactionAsync(newTransaction, true);
                                await _accountRestService.UpdateAccountAsync(target, false);
                                await _accountRestService.UpdateAccountAsync(From, false);

                                await Shell.Current.GoToAsync("..");
                                await getAllAccounts();

                            } else
                            {
                                AccountTypeError = "Error account number incorrect or does not exist";
                            }
                        }

                        break;
                    case "Transfer":
                        break;
                    default:
                        // code block
                        AccountTypeError = "there was an error";
                        break;
                }
            }
            OnPropertyChanged(nameof(AccountTypeError));
        }
    }
}
