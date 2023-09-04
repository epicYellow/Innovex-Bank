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
    class DashboardViewModel : BaseViewModel
    {
        public TransactionRestService _transactionRestService;

        public RestService _StaffRestService;

        public ObservableCollection<Transactions> AllTransactions { get; set; }

        public ObservableCollection<StaffModel> AllStaff { get; set; }

        // Transaction data
        public int Id { get; set; }
        public string Transaction_type { get; set; } = string.Empty;    
        public float Amount { get; set; }
        public string Date_and_time { get; set; } = string.Empty;
        public float Transaction_fee { get; set; }
        public int Account_Id { get; set; }

        //Staff data
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string RoleTitle { get; set; } = "User";
        public bool IsActive { get; set; } = true;

        public DashboardViewModel(TransactionRestService restService, RestService StaffRestService)
        {
            _transactionRestService = restService;
            _StaffRestService = StaffRestService;

            AllTransactions = new ObservableCollection<Transactions>();

            AllStaff = new ObservableCollection<StaffModel>();
        }

        //add rests

        public async Task getAllTransactions()
        {
            //uncomment and implement
            var Items = await _transactionRestService.RefreshDataAsync();
            AllTransactions.Clear();
            foreach (var transaction in Items)
            {
                AllTransactions.Add(transaction);
                Debug.WriteLine(transaction);
            }
        }

        public async Task getAllStaff()
        {
            //uncomment and implement
            var Items = await _StaffRestService.RefreshDataAsync();
            AllStaff.Clear();
            foreach (var staff in Items)
            {
                AllStaff.Add(staff);
                Debug.WriteLine(staff.Username);
            }
        }



    }

   
}
