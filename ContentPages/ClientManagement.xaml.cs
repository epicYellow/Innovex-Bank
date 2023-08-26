using Innovex_Bank.ViewModels;
using System.Diagnostics;
using System.Windows.Input;

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
        //fetch all clients when appear
        await _viewModel.getAllClients();
    }

    private async void NavigateToAdd(object sender, EventArgs e)
    {
        Debug.WriteLine("Navigate");

        await Shell.Current.GoToAsync("AddClient");
    }
}