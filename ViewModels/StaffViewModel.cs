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
		public ObservableCollection<StaffModel> StaffList { get; set;  }

        public StaffViewModel(RestService restService)
		{
			_restService = restService;
			StaffList = new ObservableCollection<StaffModel>();
		}

		public async Task FetchAllStaff()
		{
			var staffMembers = await _restService.RefreshDataAsync();
			StaffList.Clear();
			foreach(var staffMember in staffMembers)
			{
				StaffList.Add(staffMember);
				Debug.WriteLine(staffMember.Username);
			}
		}
	}
}

