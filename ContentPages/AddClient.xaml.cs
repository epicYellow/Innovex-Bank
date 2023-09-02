using Innovex_Bank.ViewModels;

namespace Innovex_Bank.ContentPages;

public partial class AddClient : ContentPage
{
    private ClientManagementViewModel _viewModel;

    public AddClient()
	{
		InitializeComponent();

        _viewModel = new ClientManagementViewModel(new Services.ClientRestService());

        BindingContext = _viewModel;
    }
}