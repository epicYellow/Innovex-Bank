using Innovex_Bank.ViewModels;

namespace Innovex_Bank.ContentPages;

public partial class ClientManagement : ContentPage
{
    private ClientManagementViewModel _viewModel;
    public ClientManagement()
	{
		InitializeComponent();

		_viewModel = new ClientManagementViewModel(new Services.RestService());
		BindingContext = _viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //fetch all todos when appear
        await _viewModel.getAllClients();
    }
}