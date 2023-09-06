using Innovex_Bank.ContentPages;
using Innovex_Bank.Services;
using Microsoft.Extensions.Logging;

namespace Innovex_Bank;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Lato-Regular.ttf", "LatoRegular");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddTransient<AuthService>();
        builder.Services.AddTransient<Login>();
        builder.Services.AddTransient<DashBoard>();

        return builder.Build();
	}
}
