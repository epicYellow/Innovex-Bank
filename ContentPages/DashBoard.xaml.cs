using Innovex_Bank.ViewModels;
using System.Diagnostics;

namespace Innovex_Bank.ContentPages;

public partial class DashBoard : ContentPage
{
	private DashboardViewModel _viewModel;
	public DashBoard()
	{
		InitializeComponent();

		_viewModel = new DashboardViewModel(new Services.TransactionRestService(), new Services.RestService());

		BindingContext = _viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //fetch all Transactions when appear
        await _viewModel.getAllTransactions();
		await _viewModel.getAllStaff();

		Debug.WriteLine(_viewModel.AllStaff.Count);
    }
}