using Skender.Stock.Indicators;

namespace ShareInvest.Entities;

public class Indicators
{
    public IEnumerable<MacdResult>? Macd
    {
        get; set;
    }
    public IEnumerable<SlopeResult>? Slope
    {
        get; set;
    }
    public IEnumerable<SuperTrendResult>? SuperTrend
    {
        get; set;
    }
    public IEnumerable<AtrStopResult>? AtrStop
    {
        get; set;
    }
}