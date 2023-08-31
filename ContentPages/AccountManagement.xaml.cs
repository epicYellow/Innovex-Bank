namespace Innovex_Bank.ContentPages;

using Innovex_Bank.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public partial class AccountManagement : ContentPage
{
	private AccountManageViewModel _viewModel;
	public AccountManagement()
	{
		InitializeComponent();
        _viewModel = new AccountManageViewModel(new Services.TransactionRestService());
        BindingContext = _viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //fetch all clients when appear
        await _viewModel.getAllAccounts();
        //await _viewModel.GetTransactionsById();
    }
}