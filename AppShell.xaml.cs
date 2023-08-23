using Innovex_Bank.ContentPages;
using Innovex_Bank.Services;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Innovex_Bank;

public partial class AppShell : Shell
{
	public AppShell()
    {
        InitializeComponent();

        // All routes that can be navigated to outside our flyout nav
        Routing.RegisterRoute(nameof(Login), typeof(Login));
    }

    async protected override void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(2000);

        var color = FlyoutBackgroundColor;
        FlyoutBackgroundColor = Colors.DarkBlue;
        FlyoutBackgroundColor = color;
    }
}
