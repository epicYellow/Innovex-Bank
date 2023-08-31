namespace Innovex_Bank.ContentPages;

using Innovex_Bank.ViewModels;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public partial class AccountManagement : ContentPage
{
	private AccountManageViewModel _viewModel;
	public AccountManagement()
	{
		InitializeComponent();
        _viewModel = new AccountManageViewModel(new Services.TransactionRestService(), new Services.ClientRestService(), new Services.AccountRestService());
        BindingContext = _viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //fetch all clients when appear
        await _viewModel.getAllAccounts();
    }

    private async void NavigateToAdd(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddAccount");
    }
}