using System.Diagnostics;
using Innovex_Bank.ViewModels;

namespace Innovex_Bank.ContentPages;

public partial class StaffManagement : ContentPage
{
	private StaffViewModel _staffViewModel;

	public StaffManagement()
	{

		InitializeComponent();

		// Initialise our service
		_staffViewModel = new StaffViewModel(new Services.RestService());
		BindingContext = _staffViewModel;
	}

	// This will run OnAppear
    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await _staffViewModel.FetchAllStaff();
    }
}