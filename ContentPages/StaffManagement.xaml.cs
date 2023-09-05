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
		_staffViewModel = new StaffViewModel(new Services.StaffService());
		BindingContext = _staffViewModel;
	}

    private async void NavigateToAddStaff(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddStaff");
    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
	{
		string searchText = e.NewTextValue.Trim();
		_staffViewModel.FilterStaffAsync(searchText);
	}

	// This will run OnAppear
    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await _staffViewModel.FetchAllStaff();
    }
}