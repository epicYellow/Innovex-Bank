using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Innovex_Bank.ContentPages;
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

namespace Innovex_Bank.ViewModels;

public class LoginVModel : BaseViewModel
{
    public AuthService _authService;
    public string Email { get; set; }
    public string Password { get; set; }
    public ICommand LoginCommand { get; set; }
    public ICommand LogoutCommand { get; set; }

    public LoginVModel(AuthService authService)
    {
        _authService = authService;
        LoginCommand = new Command(async () => await UserLogin());
  
    }

    private async Task UserLogin()
    {
        var user = new Staff
        {
            Email = Email,
            Password = Password
        };

        Debug.WriteLine(user.Email);
        Debug.WriteLine(user.Password);

        var (authState, userId) = await _authService.LoginUser(user);
        var test = await _authService.LoginUser(user);

        if (authState)
        {
            // Store the user ID in a property for future use
            int loggedInUserId = userId; // This is the user ID
            Debug.WriteLine(userId);

            // You can now navigate to another page or perform any other actions based on the user ID.
            await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
        }
        else
        {
            // Handle authentication failure
            Debug.WriteLine("Something happened");
        }
    }
}