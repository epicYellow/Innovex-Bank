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
using System.Text.RegularExpressions;
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
    public string EmailErrorMessage { get; set; }
    public string PasswordErrorMessage { get; set; }

    public LoginVModel(AuthService authService)
    {
        _authService = authService;
        LoginCommand = new Command(async () => await UserLogin());
  
    }

    private async Task UserLogin()
    {
        // Clear previous error messages
        EmailErrorMessage = "";
        PasswordErrorMessage = "";

        // Validate email format
        if (string.IsNullOrWhiteSpace(Email))
        {
            EmailErrorMessage = "Email is required.";
        }
        else if (!IsValidEmail(Email))
        {
            EmailErrorMessage = "Invalid email format.";
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            PasswordErrorMessage = "Password is required.";
        }

        // Check if there are any validation errors
        if (!string.IsNullOrEmpty(EmailErrorMessage) || !string.IsNullOrEmpty(PasswordErrorMessage))
        {
            // Update the bindings to display error messages
            OnPropertyChanged(nameof(EmailErrorMessage));
            OnPropertyChanged(nameof(PasswordErrorMessage));
            return; // Return early if there are validation errors
        }

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

    private bool IsValidEmail(string email)
    {
        // A simple regex pattern to check for valid email format
        string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
        return Regex.IsMatch(email, pattern);
    }
}