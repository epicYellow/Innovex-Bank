using Innovex_Bank.Models;
using Innovex_Bank.ViewModels;
using System.Diagnostics;

namespace Innovex_Bank.ContentPages;

public partial class MakeTransaction : ContentPage
{
	private AccountManageViewModel _accountManageViewModel;
	public MakeTransaction(Innovex_Bank.Accounts.Accounts accountData)
	{
		InitializeComponent();
		_accountManageViewModel = new AccountManageViewModel(new Services.TransactionRestService(), new Services.ClientRestService(), new Services.AccountRestService());
		BindingContext = _accountManageViewModel;

        _ = _accountManageViewModel.updateTransValues(accountData);
    }

	public void Change(object sender, EventArgs e)
	{
		Debug.WriteLine("this one");
		_accountManageViewModel.CheckFromTo();
	}
}