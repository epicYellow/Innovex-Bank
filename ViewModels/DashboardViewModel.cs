using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Collections;

namespace Innovex_Bank.ViewModels
{
    class DashboardViewModel : BaseViewModel
    {
        public TransactionRestService _transactionRestService;

        public RestService _StaffRestService;

        public ClientRestService _ClientRestService;

        public AccountRestService _accountRestService;

        public StaffService _staffService;
        

        public ObservableCollection<Transactions> AllTransactions { get; set; }

        public ObservableCollection<Staff> AllStaff { get; set; }

        public ObservableCollection<Client> AllClients { get; set; }

        public ObservableCollection<Accounts> AllAccounts { get; set; }


        //total withdrawn 
        private float _totalWithdrawn;
        public float TotalWithdrawn
        {
            get => _totalWithdrawn;
            set
            {
                _totalWithdrawn = value;
                OnPropertyChanged(nameof(TotalWithdrawn));
            }
        }

        //total deposit
        private float _totalDeposited;
        public float TotalDeposited
        {
            get => _totalDeposited;
            set
            {
                _totalDeposited = value;
                OnPropertyChanged(nameof(TotalDeposited));
            }
        }

        //total Clients
        private int _totalClients;
        public int TotalClients
        {
            get { return _totalClients; }
            set
            {
                if (_totalClients != value)
                {
                    _totalClients = value;
                    OnPropertyChanged(nameof(TotalClients)); 
                }
            }
        }

        //total Clients
        private int _totalAccounts;
        public int TotalAccounts
        {
            get { return _totalAccounts; }
            set
            {
                if (_totalAccounts != value)
                {
                    _totalAccounts = value;
                    OnPropertyChanged(nameof(TotalAccounts)); 
                }
            }
        }



        public DashboardViewModel(TransactionRestService restService, RestService StaffRestService, ClientRestService ClientRestService, StaffService staffService)
        {
            _transactionRestService = restService;
            _StaffRestService = StaffRestService;
            _ClientRestService = ClientRestService;
            _staffService = staffService;

            AllTransactions = new ObservableCollection<Transactions>();

            AllStaff = new ObservableCollection<Staff>();

            AllClients = new ObservableCollection<Client>();

            AllAccounts = new ObservableCollection<Accounts>();  
        }

 
        //get all transactions and withdrawl and deposits
        public async Task GetAllTransactions()
        {
            var Items = await _transactionRestService.RefreshDataAsync();

            AllTransactions.Clear();

            // Initialize variables to keep track of total withdrawn and total deposited
            TotalWithdrawn = 0;
            TotalDeposited = 0;

            foreach (var transaction in Items)
            {
                AllTransactions.Add(transaction);
                Debug.WriteLine(transaction.Amount);

                // Check the transaction type and update the appropriate total
                if (transaction.Transaction_type == "Withdrawl")
                {
                    TotalWithdrawn += transaction.Amount;
                }
                else if (transaction.Transaction_type == "Deposit")
                {
                    TotalDeposited += transaction.Amount;
                }
            }

            //totalWithdrawn and totalDeposited values available
            Debug.WriteLine("Total Withdrawn: " + TotalWithdrawn);
            Debug.WriteLine("Total Deposited: " + TotalDeposited);
        }
        



        // get total amount for all transactions
        public float CalculateTotalAmount()
        {
            float totalAmount = 0;

            foreach (var transaction in AllTransactions)
            {
                totalAmount += transaction.Amount;
            }

            return totalAmount;
        }

        //sets total amount for all transactions
        public float TotalAmount
        {
            get => CalculateTotalAmount(); 
        }

        public float TotalStaff { get; set; }


        //get staff with error handling
        public async Task GetAllStaff()
        {
            try
            {
                var Items = await _staffService.RefreshStaffAsync();
                AllStaff.Clear();
                if (Items != null)
                {
                    TotalStaff = Items.Count;
                    Debug.WriteLine("This is the count of the number of staff member");
                    Debug.WriteLine(TotalStaff);

                    OnPropertyChanged(nameof(TotalStaff));
                    foreach (var staff in Items)
                    {
                        AllStaff.Add(staff);
                        Debug.WriteLine("Testing");
                        Debug.WriteLine(staff.Name);
                    }
                }
                else
                {
                    // Handle the case where the result from RefreshDataAsync is null.
                    Debug.WriteLine("No data received from the Staff service.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the operation.
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task GetAllClients()
        {
            try
            {
                var Items = await _ClientRestService.RefreshClientAsync();
                AllClients.Clear();
                if (Items != null)
                {
                    TotalClients = Items.Count;

                    // Clear the collection if needed
                    AllClients.Clear();

                    foreach (var client in Items)
                    {
                        AllClients.Add(client);
                        Debug.WriteLine(client);
                    }
                }
                else
                {
                    // Handle the case where the result from RefreshClientAsync is null.
                    Debug.WriteLine("No data received from the Client Service.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the operation.
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task GetAllAccounts()
        {
            try
            {
                var Items = await _transactionRestService.RefreshAccountsync();
                AllAccounts.Clear();
                if (Items != null)
                {
                    TotalAccounts = Items.Count;

                    // Clear the collection if needed
                    AllAccounts.Clear();

                    foreach (var account in Items)
                    {
                        AllAccounts.Add(account);
                        Debug.WriteLine(account.Client_name);
                    }
                }
                else
                {
                    // Handle the case where the result from RefreshAccountsAsync is null.
                    Debug.WriteLine("No data received from the Account Service.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the operation.
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
