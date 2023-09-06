using Innovex_Bank.ViewModels;
using Innovex_Bank.Services;

namespace Innovex_Bank.ContentPages;

public partial class AddStaff : ContentPage
{
	private readonly StaffViewModel _staffViewModel;
	public AddStaff()
	{
		InitializeComponent();
		_staffViewModel = new StaffViewModel(new StaffService());
		BindingContext = _staffViewModel;
	}
}