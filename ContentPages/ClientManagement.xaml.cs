using Innovex_Bank.Models;
using Innovex_Bank.ViewModels;
using Microsoft.Maui.Platform;
using System.Diagnostics;
using System.Windows.Input;

namespace Innovex_Bank.ContentPages;

public partial class ClientManagement : ContentPage
{
    private ClientManagementViewModel _viewModel;
    public ClientManagement()
	{
		InitializeComponent();

		_viewModel = new ClientManagementViewModel(new Services.ClientRestService());

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

    private void EditButton_Clicked(object sender, EventArgs e)
    {
        // Retrieve the button that was clicked
        Button button = (Button)sender;

        // Retrieve the associated client's ID from the button's BindingContext
        if (button.BindingContext is Client client)
        {
            int clientId = client.Id;

            // Now, you have the ID, and you can navigate or perform any action as needed.
            Debug.WriteLine($"Edit button clicked for client ID: {clientId}");
        }
    }
}