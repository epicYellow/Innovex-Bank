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
        await _viewModel.GetAllTransactions();
		await _viewModel.GetAllStaff();

        totalAmountLabel.Text = _viewModel.TotalAmount.ToString();

        float totalWithdrawn = _viewModel.TotalWithdrawn;
        float totalDeposited = _viewModel.TotalDeposited;

        //totalWithdrawn.Label = totalWithdrawn

        Debug.WriteLine(_viewModel.AllStaff.Count);
    }
}