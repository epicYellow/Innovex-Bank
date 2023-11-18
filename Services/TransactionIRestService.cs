using Innovex_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.Services
{
    public interface TransactionIRestService
    {
        Task<List<Transactions>> RefreshDataAsync();

        Task<List<Innovex_Bank.Accounts.Accounts>> RefreshAccountsync();

        Task<List<Transactions>> RetrieveTransactionsById(int id);
    }
}
