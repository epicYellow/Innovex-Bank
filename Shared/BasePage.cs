using System.Diagnostics;

namespace Innovex_Bank.Shared;

public class BasePage : ContentPage
{
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Retrieve the user ID from preferences
        int userId = Preferences.Default.Get("UserId", -1);

        if (userId != -1)
        {
            Debug.WriteLine($"User ID: {userId}");
        }
        else
        {
            Debug.WriteLine("User ID not found in preferences.");
        }
    }
}