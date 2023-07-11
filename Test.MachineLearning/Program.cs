using Microsoft.Extensions.Configuration;

using Newtonsoft.Json.Linq;

using ShareInvest;
using ShareInvest.Ant;
using ShareInvest.Google;
using ShareInvest.Infrastructure;
using ShareInvest.Models;
using ShareInvest.Properties;

using System.Media;
using System.Runtime.Versioning;

[assembly: SupportedOSPlatform("windows")]

var configuration =

    new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                              .AddJsonFile(Resources.SETTINGS)
                              .Build();

var api = new TacticianClient(configuration.GetConnectionString(Resources.URI)!);

var tts = new TextToSpeech(Resources.GOOGLESERVICE);

string chartRoute = configuration.GetConnectionString(Resources.CHART)!,
       route = configuration.GetConnectionString(Resources.ROUTE)!;

const int period = 0x400;

if (PlatformID.Win32NT == Environment.OSVersion.Platform)
{
    using (var sp = new SoundPlayer(Resources.MARIO))
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
var probability = (stack.Count(o => o.Satisfy) / (double)stack.Count).ToString("P3");

Console.WriteLine(new
{
    Satisfy = probability
});
if (PlatformID.Win32NT == Environment.OSVersion.Platform)
{
    using (var ms = new MemoryStream())
    {
        var stream = await tts.SynthesizeSpeechAsync(ms, $"The probability of being satisfied is {probability}.");

        using (var sp = new SoundPlayer(stream))
        {
            sp.PlaySync();
        }
    }
}