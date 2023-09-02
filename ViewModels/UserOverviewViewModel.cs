using CommunityToolkit.Mvvm.ComponentModel;
using Innovex_Bank.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innovex_Bank.ViewModels
{
    class UserOverviewViewModel : BaseViewModel
    {

        //add rests
        public ObservableCollection<StaffModel> AllStaff { get; set; }
        

        //remove void and add rest return type
        public void AccountsViewModel()
        {
            AllStaff = new ObservableCollection<StaffModel>();
        }
       

        public async Task getAllAccounts()
        {
            //uncomment and implement
            //var Items = await _rest.RefreshDataAsync();
            AllStaff.Clear();
            foreach (var staff in AllStaff)
            {
                AllStaff.Add(staff);
                Debug.WriteLine(staff);
            }
        }

      

    }
}
