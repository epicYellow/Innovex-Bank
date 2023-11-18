using Innovex_Bank.Models;
using Innovex_Bank.ViewModels;

namespace Innovex_Bank.ContentPages;

public partial class EditAccount : ContentPage
{
	private AccountManageViewModel _viewModel;
	public EditAccount(Innovex_Bank.Accounts.Accounts accountData)

	{
		InitializeComponent();
        _viewModel = new AccountManageViewModel(new Services.TransactionRestService(), new Services.ClientRestService(), new Services.AccountRestService());
        BindingContext = _viewModel;

        _ = _viewModel.updateEditValues(accountData);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.getAllAccountTypes();
    }
}