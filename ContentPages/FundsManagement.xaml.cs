using Innovex_Bank.ViewModels;
using System.Diagnostics;

namespace Innovex_Bank.ContentPages;

public partial class FundsManagement : ContentPage
{
    private FundsViewModel _viewModel;

    public FundsManagement()
    {
        InitializeComponent();

        _viewModel = new FundsViewModel(new Services.TransactionRestService());

        BindingContext = _viewModel;
    }



    protected override async void OnAppearing()
    {
        base.OnAppearing();
        //fetch all Transactions when appear
        //await _viewModel.GetAllTransactions();
        //await _viewModel.getAllAccounts();

        //float totalTransactionFees = _viewModel.TotalTransactionFees;
        //float overallTotalTransactionFee = _viewModel.OverallTotalTransactionFee;
      
    }
}