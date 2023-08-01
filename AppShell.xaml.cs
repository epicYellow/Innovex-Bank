namespace Innovex_Bank;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

    async protected override void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(1000);

        var color = FlyoutBackgroundColor;
        FlyoutBackgroundColor = Colors.DarkBlue;
        FlyoutBackgroundColor = color;
    }
}
