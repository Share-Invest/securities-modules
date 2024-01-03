using ShareInvest.Entities.AnTalk;

using System.Net.NetworkInformation;
using System.Text;

namespace ShareInvest;

public static class Service
{
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
    public static double KospiConsignmentMarginRate
    {
        get => kospiConsignmentMarginRate;
    }
    public static double KosdaqConsignmentMarginRate
    {
        get => kosdaqConsignmentMarginRate;
    }
    public static int KospiTransactionMultiplier
    {
        get => kospiTransactionMultiplier;
    }
    public static int KosdaqTransactionMultiplier
    {
        get => kosdaqTransactionMultiplier;
    }
    public static double Commission
    {
        get => commission;
    }
    const double kospiConsignmentMarginRate = 9e-2;
    const double kosdaqConsignmentMarginRate = 168e-3;
    const int kospiTransactionMultiplier = 250_000;
    const int kosdaqTransactionMultiplier = 10_000;
    const double commission = 3e-5;
}