using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace ShareInvest;

public static partial class Extensions
{
    public static WebApplicationBuilder Configure(this WebApplicationBuilder builder)
    {
        builder.Services
            .Configure<KestrelServerOptions>(o =>
            {
                o.ListenAnyIP(18181, o => o.UseConnectionLogging());
                o.Limits.MaxRequestBodySize = null;
            })
            .AddControllersWithViews(configure =>
            {

            })
            .AddJsonOptions(configure =>
            {
                configure.JsonSerializerOptions.WriteIndented =
#if DEBUG
                true;
#else
                false;
#endif
            });
        builder.Services.AddRazorPages(configure =>
        {

        });
        return builder;
    }
}