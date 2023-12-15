using ShareInvest.Entities;

namespace ShareInvest.Utilities;

public static class TreeMap
{
    public static object SetGroupByTheme(HighGrowthRateTheme theme, IEnumerable<TreeMapStock> items)
    {
        return new
        {
            theme = new object[]
            {
                new
                {
                    items,
                    theme.Code,
                    theme.Name,
                    theme.RateCompareToPreviousDay,
                    theme.AverageRateLastThreeDays
                }
            }
        };
    }
}