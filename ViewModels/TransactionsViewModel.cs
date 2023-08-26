using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.ViewModels
{
    internal class TransactionsViewModel : BaseViewModel
    {

        public TransactionRestService _restService;

        public List<Transactions> TransactionList;

        public TransactionsViewModel(TransactionRestService restService)
        {
            _restService = restService;
            TransactionList = new List<Transactions>();
        }

        public async Task FetchAllTransactions()
        {
            var items = await _restService.RefreshDataAsync();
            TransactionList.Clear();
            foreach (var item in items)
            {
                TransactionList.Add(item);
                Debug.WriteLine(item.Amount);
            }
        }

        

    }
}
