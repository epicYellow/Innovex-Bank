using System;
using Innovex_Bank.Services;
using Innovex_Bank.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Innovex_Bank.ViewModels
{
	class StaffViewModel: BaseViewModel
	{
		public StaffService _staffService;

		// Define all the observed properties
		public ObservableCollection<Staff> StaffList { get; set;  }

        // Properties for input fields
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdNumber { get; set; }
        public string Income { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string RoleTitle { get; set; }

        // Error message properties for input fields
        public string NameErrorMessage { get; set; } 
        public string SurnameErrorMessage { get; set; } 
        public string IdNumberErrorMessage { get; set; } 
        public string IncomeErrorMessage { get; set; } 
        public string PasswordErrorMessage { get; set; } 
        public string EmailErrorMessage { get; set; }
        public string RoleTitleErrorMessage { get; set; } 

        public ICommand AddNewMemberCommand { get; }

        private int _selectedUserId;

        public StaffViewModel(StaffService staffService)
		{
            _staffService = staffService;
			StaffList = new ObservableCollection<Staff>();

            AddNewMemberCommand = new Command(async () => AddMember());
        }

        public async Task UpdateStaffAsync(Staff updatedUser)
        {
            // Update the user data in the backend
            await _staffService.UpdateStaffAsync(updatedUser);
            await Shell.Current.GoToAsync("..");
        }

        private async void AddMember()
        {
            Debug.WriteLine("Lol");
            Debug.WriteLine(NameErrorMessage);
            // Validate fields
            ValidateName();
            ValidateSurname();
            ValidateIdNumber();
            ValidateIncome();
            ValidatePassword();
            ValidateEmail();
            ValidateRoleTitle();

            if (string.IsNullOrEmpty(NameErrorMessage) &&
                string.IsNullOrEmpty(SurnameErrorMessage) &&
                string.IsNullOrEmpty(IdNumberErrorMessage) &&
                string.IsNullOrEmpty(IncomeErrorMessage) &&
                string.IsNullOrEmpty(PasswordErrorMessage) &&
                string.IsNullOrEmpty(EmailErrorMessage) &&
                string.IsNullOrEmpty(RoleTitleErrorMessage))
            {
                var newMember = new Staff
                {
                    Name = Name,
                    Surname = Surname,
                    IdNumber = IdNumber,
                    Income = float.Parse(Income),
                    Password = Password,
                    Email = Email,
                    RoleTitle = RoleTitle
                };
                Debug.WriteLine(newMember);
                await _staffService.SaveStaffAsync(newMember, true);
                await Shell.Current.GoToAsync("..");
            }
           
        }

        public async Task FetchAllStaff()
		{
			var staffList = await _staffService.RefreshStaffAsync();
			StaffList.Clear();
			foreach(var member in staffList)
			{
				StaffList.Add(member);
				Debug.WriteLine(member.Name);
			}
		}

		public async Task FilterStaffAsync(string searchText)
		{
			if (string.IsNullOrWhiteSpace(searchText))
			{
                var staffList = await _staffService.RefreshStaffAsync();
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

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name)) { 
                Debug.WriteLine("hey");
                NameErrorMessage = "Name is required.";
            } 
            else
            {
                NameErrorMessage = string.Empty;
            }

            OnPropertyChanged(nameof(NameErrorMessage));

        }

        private void ValidateSurname()
        {
            if (string.IsNullOrWhiteSpace(Surname))
                SurnameErrorMessage = "Surname is required.";
            else
                SurnameErrorMessage = string.Empty;
            OnPropertyChanged(nameof(SurnameErrorMessage));
        }

        private void ValidateIdNumber()
        {
            if (string.IsNullOrWhiteSpace(IdNumber))
                IdNumberErrorMessage = "ID Number is required.";
            else if (IdNumber.Length != 13)
                IdNumberErrorMessage = "ID Number must be 13 characters long.";
            else
                IdNumberErrorMessage = string.Empty;

            OnPropertyChanged(nameof(IdNumberErrorMessage));
        }

        private void ValidateIncome()
        {
            if (string.IsNullOrWhiteSpace(Income))
                IncomeErrorMessage = "Income is required.";
            else
                IncomeErrorMessage = string.Empty;

            OnPropertyChanged(nameof(IncomeErrorMessage));
        }

        private void ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(Password))
                PasswordErrorMessage = "Password is required.";
            else
                PasswordErrorMessage = string.Empty;

            OnPropertyChanged(nameof(PasswordErrorMessage));
        }

        private void ValidateEmail()
        {
            if (string.IsNullOrWhiteSpace(Email))
                EmailErrorMessage = "Email is required.";
            else if (!IsValidEmail(Email))
                EmailErrorMessage = "Invalid email format.";
            else
                EmailErrorMessage = string.Empty;

            OnPropertyChanged(nameof(EmailErrorMessage));
        }

        private void ValidateRoleTitle()
        {
            if (string.IsNullOrWhiteSpace(RoleTitle))
                RoleTitleErrorMessage = "Role Title is required.";
            else
                RoleTitleErrorMessage = string.Empty;

            OnPropertyChanged(nameof(RoleTitleErrorMessage));
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        
    }
}

