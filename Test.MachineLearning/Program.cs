using Microsoft.Extensions.Configuration;

using ShareInvest;
using ShareInvest.Infrastructure;
using ShareInvest.Properties;

using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("windows")]

var route = Extensions.Configuration.GetConnectionString(Resources.ROUTE) ?? string.Empty;

if (Extensions.Configuration.GetConnectionString(Resources.URI) is string url)
{
    if (PlatformID.Win32NT == Environment.OSVersion.Platform)
    {
        using (var sp = new System.Media.SoundPlayer(Resources.MARIO))
        {
            sp.PlaySync();
        }
    }
    var api = new TacticianClient(url);

    foreach (var code in await api.GetCodeInventoryAsync(route))
    {
        Console.WriteLine(code);
    }
}