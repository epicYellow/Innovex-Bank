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

        public ICommand ResetTotalsCommand { get; }
       

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

        private float _totalTransactionAmount;
        public float TotalTransactionAmount
        {
            get => _totalTransactionAmount;
            set => SetProperty(ref _totalTransactionAmount, value);
        }

        private void ExecuteResetTotalsCommand()
        {
            // Call the ResetTotalAmounts function when the button is clicked
            ResetTotalAmounts();
        }




        public FundsViewModel(TransactionRestService restService)
        {
            _transactionRestService = restService;

            AllTransactions = new ObservableCollection<Transactions>();

            AllAccounts = new ObservableCollection<Accounts>();

            TotalTransactionFees = 0;

             ResetTotalsCommand = new Command(ExecuteResetTotalsCommand);

    }

    public async Task GetAllTransactions()
        {
            var Items = await _transactionRestService.RefreshDataAsync();

            AllTransactions.Clear();

            List<int> accountIds = new List<int>();
            float totalAmount = 0;

            foreach (var transaction in Items)
            {
                AllTransactions.Add(transaction);

                accountIds.Add(transaction.Account_Id);

                totalAmount += transaction.Amount;
            }


            TotalTransactionAmount = totalAmount;
        }


        public async Task getAllAccounts()
        {
            var Items = await _transactionRestService.RefreshAccountsync();
            AllAccounts.Clear();

           
            OverallTotalTransactionFee = 0;

            foreach (var account in Items)
            {
                AllAccounts.Add(account);
                Debug.WriteLine(account);
                
                float TotalTransactionFee = CalculateTotalTransactionFeeForAccount(account.Id);
               

                OverallTotalTransactionFee += TotalTransactionFee;
                Debug.WriteLine(OverallTotalTransactionFee);
            }

           
            Debug.WriteLine($"Overall Total Transaction Fee: {OverallTotalTransactionFee}");
        }


        private float CalculateTotalTransactionFeeForAccount(int accountId)
        {
            float totalFee = 0;

            foreach (var account in AllAccounts)
            {
                if (account.Id == accountId)
                {
                    
                    totalFee += account.Transaction_fee;
                }
            }

            return totalFee;
        }


        public void ResetTotalAmounts()
        {

            OverallTotalTransactionFee = 0;
            TotalTransactionAmount = 0;
            Debug.WriteLine("Month values reset");
        }


        //calculate oercentage of transaction amounts
        //private float CalculateTransactionFee(float transactionAmount)
        //{

        //  float feePercentage = 0.02f; 
        // float fee = transactionAmount * feePercentage;



        //return fee;
        //}



    }
}
