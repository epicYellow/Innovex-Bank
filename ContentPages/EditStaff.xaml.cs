using Innovex_Bank.Models;
using Innovex_Bank.Services;
using System.Diagnostics;
using Windows.System;

namespace Innovex_Bank.ContentPages;

public partial class EditStaff : ContentPage
{
    public Staff SelectedUser { get; set; }
    private Staff originalUserData;
    private StaffService _staffService; 

    public EditStaff(Staff selectedUser)
    {
        InitializeComponent();
        // Store the selected user ID in a local variable or property for later use
        SelectedUser = selectedUser;
        _staffService = new StaffService();

        originalUserData = new Staff
        {
            Name = selectedUser.Name,
            Surname = selectedUser.Surname,
            IdNumber = selectedUser.IdNumber,
            Income = selectedUser.Income,
            Password = selectedUser.Password,
            Email = selectedUser.Email,
            RoleTitle = selectedUser.RoleTitle
        };

        BindingContext = SelectedUser = selectedUser;

        // Add TextChanged event handlers to detect changes
        entryName.TextChanged += Entry_TextChanged;
        entrySurname.TextChanged += Entry_TextChanged;
        entryIdNumber.TextChanged += Entry_TextChanged;
        entryIncome.TextChanged += Entry_TextChanged;
        entryEmail.TextChanged += Entry_TextChanged;
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Check if any data has changed
        bool dataChanged = !string.Equals(originalUserData.Name, SelectedUser.Name) ||
                           !string.Equals(originalUserData.Surname, SelectedUser.Surname) ||
                           !string.Equals(originalUserData.IdNumber, SelectedUser.IdNumber) ||
                           !float.Equals(originalUserData.Income, SelectedUser.Income) ||
                           !string.Equals(originalUserData.Email, SelectedUser.Email) ||
                           !string.Equals(originalUserData.RoleTitle, SelectedUser.RoleTitle);

        // Update the visibility of the "Update Client" button
        updateButton.IsVisible = dataChanged;
    }

    private async void UpdateButton_Clicked(object sender, EventArgs e)
    {
        // Update the SelectedUser with the edited data
        // (You may also want to validate the data here)

        await _staffService.UpdateStaffAsync(SelectedUser);
        await Shell.Current.GoToAsync("..");

        // Optionally, navigate back or show a success message
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        var confirmed = await DisplayAlert("Confirmation", "Are you sure you want to delete this user?", "Yes", "No");

        if (confirmed)
        {
            // Delete the user using _staffService
            await _staffService.DeleteStaffAsync(SelectedUser.Id);

            // Optionally, navigate back or show a success message
            await Shell.Current.GoToAsync("..");
        }
    }
}