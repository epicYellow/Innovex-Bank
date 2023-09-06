using Innovex_Bank.ContentPages;
using Innovex_Bank.ContentViews.AccountManagement;
using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System.Diagnostics;

namespace Innovex_Bank;

public partial class AppShell : Shell
{
    private readonly StaffService _staffService;
    private readonly AuthService _authService;
    private Staff _currentUser;
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("AddClient", typeof(AddClient));
        Routing.RegisterRoute("AddAccount", typeof(AddAccount));
        Routing.RegisterRoute("AddStaff", typeof(AddStaff));
        Routing.RegisterRoute("EditStaff", typeof(EditStaff));
        _staffService = new StaffService();
        _authService = new AuthService();
        BindingContext = this;
        Routing.RegisterRoute("UserDetails", typeof(UserDetail));
    }
    public string Email { get; set; }
    async protected override void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(2000);

        var color = FlyoutBackgroundColor;
        FlyoutBackgroundColor = Colors.DarkBlue;
        FlyoutBackgroundColor = color;

        // Get the user ID from AuthService
        int userId = Preferences.Default.Get<int>("UserId", -1);

        // Retrieve the logged-in user's details by ID
        _currentUser = await _staffService.GetStaffByIdAsync(userId);

        if (_currentUser != null)
        {
            // Now you have the user details in _currentUser
            Debug.WriteLine($"Logged-in User test ID: {_currentUser.Id}");
            Debug.WriteLine($"Logged-in User Name: {_currentUser.Name}");
            Debug.WriteLine($"Logged-in User Email: {_currentUser.Email}");
            Email = _currentUser.Email;
            Debug.WriteLine(Email);
            OnPropertyChanged(nameof(Email));
        }
        else
        {
            new AuthService().Logout();
            _ = Shell.Current.GoToAsync($"//{nameof(Login)}");
            Debug.WriteLine("Failed to retrieve user details.");
        } 
    }
}
