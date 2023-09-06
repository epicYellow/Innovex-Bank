using Innovex_Bank.Models;
using Innovex_Bank.Services;
using Innovex_Bank.Shared;
using System.Diagnostics;

namespace Innovex_Bank.ContentPages
{
    public partial class DashBoard : ContentPage
    {
        private readonly StaffService _staffService;
        private readonly AuthService _authService;
        private Staff _currentUser;
        public DashBoard()
        {
            InitializeComponent();
            _staffService = new StaffService();
            _authService = new AuthService();
        }

        public string Fullname { get; set; }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // Get the user ID from AuthService
            int userId = Preferences.Default.Get<int>("UserId", -1);

            // Retrieve the logged-in user's details by ID
            _currentUser = await _staffService.GetStaffByIdAsync(userId);

            if (_currentUser != null)
            {
                // Now you have the user details in _currentUser
                Debug.WriteLine($"Logged-in User ID: {_currentUser.Id}");
                Debug.WriteLine($"Logged-in User Name: {_currentUser.Name}");
                Debug.WriteLine($"Logged-in User Email: {_currentUser.Email}");
                Fullname = _currentUser.Name + " " + _currentUser.Surname;
            }
            else
            {
                new AuthService().Logout();
                _ = Shell.Current.GoToAsync($"//{nameof(Login)}");
                Debug.WriteLine("Failed to retrieve user details.");
            }
        }
    }
}
