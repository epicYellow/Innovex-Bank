using Innovex_Bank.Models;
using Innovex_Bank.ViewModels;
using System.Diagnostics;

namespace Innovex_Bank.ContentPages;

public partial class DashBoard : ContentPage
{

    private DashboardViewModel _viewModel;

    public DashBoard()
	{
		InitializeComponent();

		_viewModel = new DashboardViewModel(new Services.TransactionRestService(), new Services.RestService(), new Services.ClientRestService());

		BindingContext = _viewModel;
	}



    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //fetch all Transactions when appear
        await _viewModel.GetAllTransactions();
		await _viewModel.GetAllStaff();
        await _viewModel.GetAllClients();

        totalAmountLabel.Text = _viewModel.TotalAmount.ToString();
        //totalClientsLabel.Text = _viewModel.totalClients.ToString();

        float totalWithdrawn = _viewModel.TotalWithdrawn;
        float totalDeposited = _viewModel.TotalDeposited;
        int totalClients = _viewModel.TotalClients;

        //float totalAmount = _viewModel.TotalAmount;

        Debug.WriteLine(_viewModel.AllStaff.Count);
    }

  

    private async void OnViewButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("UserDetails");
    }

}