using Innovex_Bank.ContentPages;
using Innovex_Bank.ContentViews.AccountManagement;

namespace Innovex_Bank;

public partial class AppShell : Shell
{
	public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("AddClient", typeof(AddClient));
        Routing.RegisterRoute("AddAccount", typeof(AddAccount));
        Routing.RegisterRoute("EditClient", typeof(EditClient));
        Routing.RegisterRoute("EditAccount", typeof(EditAccount));
        Routing.RegisterRoute("MakeTransaction", typeof(MakeTransaction));

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
