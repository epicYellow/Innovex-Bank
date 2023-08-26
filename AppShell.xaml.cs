using Innovex_Bank.ContentPages;

namespace Innovex_Bank;

public partial class AppShell : Shell
{
	public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("AddClient", typeof(AddClient));
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
