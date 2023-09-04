using System;
using Innovex_Bank.Services;
using Innovex_Bank.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Innovex_Bank.ViewModels
{
	public class StaffViewModel: BaseViewModel
	{
		public RestService _restService;

		// Define all the observed properties
		public ObservableCollection<Staff> StaffList { get; set;  }

        public StaffViewModel(RestService restService)
		{
			_restService = restService;
			StaffList = new ObservableCollection<Staff>();
		}

		public async Task FetchAllStaff()
		{
			var staffList = await _restService.RefreshStaffAsync();
			StaffList.Clear();
			foreach(var member in staffList)
			{
				StaffList.Add(member);
			}
		}

		public async Task FilterStaffAsync(string searchText)
		{
			if (string.IsNullOrWhiteSpace(searchText))
			{
                var staffList = await _restService.RefreshStaffAsync();
                StaffList.Clear();
                foreach (var member in staffList)
                {
                    StaffList.Add(member);
                }
            } else
			{
				Debug.WriteLine(searchText);
                var filteredStaff = StaffList.Where(s => s.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                         s.Surname.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                         s.IdNumber.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
                StaffList.Clear();
                foreach (var member in filteredStaff)
                {
                    StaffList.Add(member);
                }
            }
		}
	}
}

