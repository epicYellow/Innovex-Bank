using Innovex_Bank.Services;

namespace Innovex_Bank.ContentPages;

public partial class Loading : ContentPage
{

	private AuthService _authService;
	public Loading(AuthService authService)
	{
		InitializeComponent();

		_authService = authService;
	}



	// Run the check auth function
    protected async override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

		if(_authService.IsAuthenticated())
		{
            await Shell.Current.GoToAsync($"//{nameof(DashBoard)}");
		}

		await Shell.Current.GoToAsync($"//{nameof(Login)}");
    }
}