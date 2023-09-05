using Innovex_Bank.ContentPages;
using Innovex_Bank.Services;
using Innovex_Bank.ViewModels;

namespace Innovex_Bank.ContentViews;

public partial class PageHeader : ContentView
{

	public static BindableProperty PageProperty =
		BindableProperty.Create(nameof(PageTitle), typeof(string), typeof(PageHeader), default(string));

	public string PageTitle
	{
		get => (string)GetValue(PageProperty);
		set => SetValue(PageProperty, value);
	}

    private readonly AuthService _authService;
    private LoginVModel _loginVModel;
    public PageHeader()
    {
        InitializeComponent();
        _loginVModel = new LoginVModel(new Services.AuthService());
        BindingContext = _loginVModel;

        _authService = new AuthService();
    }

    private async void Logout_Clicked(object sender, EventArgs e)
    {
        new AuthService().Logout();
        _ = Shell.Current.GoToAsync($"//{nameof(Login)}");
    }
}