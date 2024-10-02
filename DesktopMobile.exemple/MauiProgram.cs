using Microsoft.Extensions.Logging;

namespace DesktopMobile.exemple
{
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMsalAuthentication(options =>
            {
                var authentication = options.ProviderOptions.Authentication;
                authentication.Authority = "https://localhost:5001";
                authentication.ClientId = "client_id_credentials";
                authentication.RedirectUri = "com.client.credentials://callback";
                authentication.PostLogoutRedirectUri = "com.client.credentials://callback";
            });
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
