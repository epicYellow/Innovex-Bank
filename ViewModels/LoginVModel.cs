using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Innovex_Bank.ContentPages;
using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Innovex_Bank.ViewModels;

public  class LoginVModel : BaseViewModel
{
    public AuthService _authService;
    public string Email { get; set; }
    public string Password { get; set; }

    public ICommand LoginCommand { get; set; }

    public LoginVModel(AuthService authService) {
        _authService = authService;
        LoginCommand = new Command(async () => await UserLogin());
    }

    private async Task UserLogin()
    {
        var user = new StaffModel
        {
            Email = Email,
            Password = Password
        };

        var authState = await _authService.LoginUser(user);

        if (authState)
        {
            await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
        }
    }
}

