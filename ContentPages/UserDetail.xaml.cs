using Innovex_Bank.ViewModels;
using System.Diagnostics;

namespace Innovex_Bank.ContentPages;

public partial class UserDetail : ContentPage
{

    private DashboardViewModel _viewModel;
    public UserDetail()
	{
        InitializeComponent();

        Debug.WriteLine("on userdetail page");

        _viewModel = new DashboardViewModel(new Services.TransactionRestService(), new Services.RestService(), new Services.ClientRestService(), new Services.StaffService());

        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //fetch all Transactions when appear
        await _viewModel.GetAllTransactions();
        await _viewModel.GetAllStaff();
    }
}