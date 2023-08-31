using Innovex_Bank.ViewModels;

namespace Innovex_Bank.ContentViews.AccountManagement;

public partial class AddAccount : ContentPage
{
	private AccountManageViewModel viewModel;
	public AddAccount()
	{
		InitializeComponent();

        viewModel = new AccountManageViewModel(new Services.TransactionRestService(), new Services.ClientRestService(), new Services.AccountRestService());

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //fetch all clients when appear
        await viewModel.getAllClients();
        await viewModel.getAllAccountTypes();
    }
}