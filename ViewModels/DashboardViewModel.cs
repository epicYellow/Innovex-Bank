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

        public ObservableCollection<Transactions> AllTransactions { get; set; }

        public ObservableCollection<StaffModel> AllStaff { get; set; }

       

        // Transaction data
       


        //withdrawl and desposit 
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



        public DashboardViewModel(TransactionRestService restService, RestService StaffRestService)
        {
            _transactionRestService = restService;
            _StaffRestService = StaffRestService;

            AllTransactions = new ObservableCollection<Transactions>();

            AllStaff = new ObservableCollection<StaffModel>();
        }

 
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

            // Now, you have the totalWithdrawn and totalDeposited values available
            Debug.WriteLine("Total Withdrawn: " + TotalWithdrawn);
            Debug.WriteLine("Total Deposited: " + TotalDeposited);
        }
        




        public float CalculateTotalAmount()
        {
            float totalAmount = 0;

            foreach (var transaction in AllTransactions)
            {
                totalAmount += transaction.Amount;
            }

            return totalAmount;
        }

     
        public float TotalAmount
        {
            get => CalculateTotalAmount(); // Assuming CalculateTotalAmount is a method in your ViewModel
        }




        //get staff with error handling
        public async Task GetAllStaff()
        {
            try
            {
                var Items = await _StaffRestService.RefreshDataAsync();
                AllStaff.Clear();
                if (Items != null)
                {
                    
                    foreach (var staff in Items)
                    {
                        AllStaff.Add(staff);
                        Debug.WriteLine(staff.Fullname);
                    }
                }
                else
                {
                    // Handle the case where the result from RefreshDataAsync is null.
                    Debug.WriteLine("No data received from the service.");
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
