using Microsoft.Extensions.Configuration;

using Newtonsoft.Json.Linq;

using ShareInvest;
using ShareInvest.Ant;
using ShareInvest.Infrastructure;
using ShareInvest.Models;
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
    var stack = new Stack<InputConditionData>(codeInventory.Length);

    foreach (var code in codeInventory)
    {
        var inventory = await api.GetChartInventoryAsync(chartRoute, JToken.FromObject(new
        {
            code,
            period
        }));
        DataPreprocessing dp =

            new(Array.FindAll(inventory?.Charts ?? Array.Empty<Chart>(), m => string.IsNullOrEmpty(m.DateTime) is false)
                     .OrderBy(ks => ks.DateTime)
                     .ToList());

        dp.Send += (sender, e) => stack.Push(e);

        dp.StartProcess();
    }
    Console.WriteLine((stack.Count(o => o.Satisfy) / (double)stack.Count).ToString("P3"));
}