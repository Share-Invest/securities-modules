using ShareInvest.Entities.AnTalk;
using ShareInvest.Properties;

using Skender.Stock.Indicators;

using System.Collections.Concurrent;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;

namespace ShareInvest;

public static class Service
{
    public static void AnalyzeFuturesQuotes(string code, string[] futuresData)
    {
        _ = DateTime.TryParseExact(string.Concat(DateTime.Now.ToString(Resources.DATE), futuresData[0]), dateFormat, null, DateTimeStyles.None, out var time);

        if (Cache.GetFuturesData(code) is ConcurrentStack<Quote> quotes)
        {
            if (quotes.TryPeek(out var latestQuote) && latestQuote.Date.Minute != time.Minute)
            {
                latestQuote.Close = Math.Abs(Convert.ToDecimal(futuresData[1]));
                latestQuote.Open = Math.Abs(Convert.ToDecimal(futuresData[9]));
                latestQuote.High = Math.Abs(Convert.ToDecimal(futuresData[10]));
                latestQuote.Low = Math.Abs(Convert.ToDecimal(futuresData[11]));
                latestQuote.Volume = Convert.ToDecimal(futuresData[7]);
            }
            else
            {
                quotes.Push(new Quote
                {
                    Date = time,
                    Close = Math.Abs(Convert.ToDecimal(futuresData[1])),
                    Open = Math.Abs(Convert.ToDecimal(futuresData[9])),
                    High = Math.Abs(Convert.ToDecimal(futuresData[10])),
                    Low = Math.Abs(Convert.ToDecimal(futuresData[11])),
                    Volume = Convert.ToDecimal(futuresData[7])
                });
            }
        }
    }
    public static object? ProvideComparableChart(IEnumerable<AssetStatusChart> chart)
    {
        Queue<AssetStatusChart> previous = new(), present = new();

        int previousMonth = 0, previousIndex = 1, presentIndex = 1;

        foreach (var e in chart.OrderBy(o => o.Date))
        {
            if (previousMonth > 0 && previousMonth != e.Index)
            {
                present.Enqueue(new AssetStatusChart
                {
                    Date = e.Date,
                    Asset = e.Asset,
                    Index = presentIndex++
                });
                continue;
            }
            previous.Enqueue(new AssetStatusChart
            {
                Date = e.Date,
                Asset = e.Asset,
                Index = previousIndex++
            });
            previousMonth = e.Index;
        }
        return previous.Count <= 0 ? null : new
        {
            previous,
            present,
            minX = 1,
            maxX = (previousIndex > presentIndex ? previousIndex : presentIndex) - 1,
            minY = chart.Min(o => o.Asset),
            maxY = chart.Max(o => o.Asset)
        };
    }
    public static string GetMacAddress()
    {
        foreach (var net in NetworkInterface.GetAllNetworkInterfaces())
        {
            var mac = net.GetPhysicalAddress().ToString();

            var sb = new StringBuilder();

            for (int i = 0; i < mac.Length; i++)
            {
                sb.Append(mac[i]);

                if (i % 2 == 1 && i < mac.Length - 1)
                {
                    sb.Append(':');
                }
            }
            if (sb.Length == 0x11)
            {
                return sb.ToString();
            }
        }
        return string.Empty;
    }
    const string dateFormat = "yyyyMMddHHmmss";
}