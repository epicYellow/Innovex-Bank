using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Audio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Innovex_Bank.ViewModels
{
    class FundsViewModel : BaseViewModel  
    {
        public TransactionRestService _transactionRestService;

        public AccountRestService _accountRestService;

        public ObservableCollection<Accounts> AllAccounts { get; set; }

        public ObservableCollection<Transactions> AllTransactions { get; set; }

        public ObservableCollection<Transactions> SelectedTransactions { get; set; }


        private float _totalTransactionFees;
        public float TotalTransactionFees
        {
            get => _totalTransactionFees;
            set => SetProperty(ref _totalTransactionFees, value);
        }


        private float overallTotalTransactionFee;
        public float OverallTotalTransactionFee
        {
            get => overallTotalTransactionFee;
            set => SetProperty(ref overallTotalTransactionFee, value);
        }




        public FundsViewModel(TransactionRestService restService)
        {
            _transactionRestService = restService;

            AllTransactions = new ObservableCollection<Transactions>();

            AllAccounts = new ObservableCollection<Accounts>();

            TotalTransactionFees = 0;
        }

        public async Task GetAllTransactions()
        {
            var Items = await _transactionRestService.RefreshDataAsync();

            AllTransactions.Clear();

            // Create a list to store Account_Ids from all transactions
            List<int> accountIds = new List<int>();

            foreach (var transaction in Items)
            {
                AllTransactions.Add(transaction);
                //Debug.WriteLine(transaction.Account_Id);

                // Collect Account_Ids
                accountIds.Add(transaction.Account_Id);

                // Check the transaction type and update the appropriate total
            }

            // Now, you have all Account_Ids in the accountIds list
            // You can use this list as needed for further processing
        }


        public async Task getAllAccounts()
        {
            var Items = await _transactionRestService.RefreshAccountsync();
            AllAccounts.Clear();

            // Initialize the overall total transaction fee to 0
            OverallTotalTransactionFee = 0;

            foreach (var account in Items)
            {
                AllAccounts.Add(account);
                Debug.WriteLine(account);

                // Calculate the total transaction fee for the current account
                float TotalTransactionFee = CalculateTotalTransactionFeeForAccount(account.Id);
                //Debug.WriteLine(TotalTransactionFee);

                // Assign the calculated total transaction fee to a property in the account object
                account.Transaction_fee = TotalTransactionFee;

                // Add the current account's transaction fee to the overall total
                OverallTotalTransactionFee += TotalTransactionFee;
                Debug.WriteLine(OverallTotalTransactionFee);
            }

            // Now, you have the overall total transaction fee in the OverallTotalTransactionFee variable
            // You can use this variable as needed
            Debug.WriteLine($"Overall Total Transaction Fee: {OverallTotalTransactionFee}");
        }


        private float CalculateTotalTransactionFeeForAccount(int accountId)
        {
            float totalFee = 0;

            foreach (var transaction in AllTransactions)
            {
                if (transaction.Account_Id == accountId)
                {
                    // Assuming you have a CalculateTransactionFee method to calculate fees
                    float fee = CalculateTransactionFee(transaction.Amount);
                    totalFee += fee;
                }
            }

            return totalFee;
        }

        private float CalculateTransactionFee(float transactionAmount)
        {
            // Implement your logic to calculate the transaction fee here
            // This could be a fixed fee or a percentage of the transaction amount
            float feePercentage = 0.02f; // Example: 2% fee
            float fee = transactionAmount * feePercentage;

            // You can also add a minimum fee if needed
            float minimumFee = 5.00f; // Example: Minimum fee of $5.00
            if (fee < minimumFee)
            {
                fee = minimumFee;
            }

            return fee;
        }






        // eers transactions kry en dan account id vat
        //dan function vir account match met account id van transaction
        // dan die fee maal met hoeveelheid trasactions




        //function om transaction by id te kry, afhangend van ander function 
        //dan n function wat daai ID vat en check vir hoe



    }
}
