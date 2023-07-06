using Microsoft.Extensions.Configuration;

using Newtonsoft.Json.Linq;

using ShareInvest.Ant;
using ShareInvest.Infrastructure;
using ShareInvest.Properties;

using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("windows")]

var configuration =

    new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                              .AddJsonFile(Resources.SETTINGS)
                              .Build();

var api = new TacticianClient(configuration.GetConnectionString(Resources.URI)!);

string chartRoute = configuration.GetConnectionString(Resources.CHART)!;

const int period = 0x400;

if (configuration.GetConnectionString(Resources.ROUTE) is string route)
{
    if (PlatformID.Win32NT == Environment.OSVersion.Platform)
    {
        using (var sp = new System.Media.SoundPlayer(Resources.MARIO))
        {
            sp.PlaySync();
        }
    }
    var codeInventory = await api.GetCodeInventoryAsync(route);
    var stack = new Stack<(Chart[], Chart[])>(codeInventory.Length);

    foreach (var code in codeInventory)
    {
        var inventory = await api.GetChartInventoryAsync(chartRoute, JToken.FromObject(new
        {
            code,
            period
        }));
        List<Chart> list =

            Array.FindAll(inventory?.Charts ?? Array.Empty<Chart>(), m => string.IsNullOrEmpty(m.DateTime) is false)
                 .OrderBy(ks => ks.DateTime)
                 .ToList();

        while (list.Count > 125)
        {
            var forecastedCharts = new Chart[5];
            var inputCharts = new Chart[120];

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (i >= list.Count - 5)
                {
                    forecastedCharts[forecastedCharts.Length - list.Count + i] = list[i];

                    continue;
                }
                if (i >= list.Count - 125)
                {
                    inputCharts[inputCharts.Length - list.Count + i + 5] = list[i];

                    continue;
                }
                stack.Push((inputCharts, forecastedCharts));

                break;
            }
            list.RemoveAt(list.Count - 1);
        }
    }
}