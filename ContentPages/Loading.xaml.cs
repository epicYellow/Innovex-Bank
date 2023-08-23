using Innovex_Bank.Services;

namespace Innovex_Bank.ContentPages;

public partial class Loading : ContentPage
{
	private readonly AuthService _authService;
	public Loading(AuthService authService)
	{
		InitializeComponent();

		_authService = authService;
	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await _authService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(Login)}");
        }
    }
}