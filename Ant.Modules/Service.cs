using ShareInvest.Entities.AnTalk;

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
}