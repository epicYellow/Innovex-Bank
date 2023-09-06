using Innovex_Bank.Models;
using Innovex_Bank.ViewModels;
using System.Diagnostics;

namespace Innovex_Bank.ContentPages;

public partial class EditClient : ContentPage
{
    private ClientManagementViewModel _viewModel;
    public EditClient(Client clientData)
	{
		InitializeComponent();

        _viewModel = new ClientManagementViewModel(new Services.ClientRestService());

        BindingContext = _viewModel;

        _ = _viewModel.updateFormValues(clientData);
    }
}