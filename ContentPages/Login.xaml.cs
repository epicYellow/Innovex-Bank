using Innovex_Bank.Services;
using Innovex_Bank.ViewModels;

namespace Innovex_Bank.ContentPages;

public partial class Login : ContentPage
{
    private readonly AuthService _authService;
    private LoginVModel _loginVModel;
    public Login(AuthService authService)
	{
		InitializeComponent();
        _loginVModel = new LoginVModel(new Services.AuthService());
        BindingContext = _loginVModel;

        _authService = authService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (await _authService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
        }

    }


}