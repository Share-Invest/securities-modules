namespace ShareInvest.Entities.TradingView;

public struct Strategics
{
    public DateTime DateTime
    {
        get; set;
    }
    public int Position
    {
        get; set;
    }
    public double Histogram
    {
        get; set;
    }
    public double Slope
    {
        get; set;
    }
    /// <summary>
    /// -1.BuyStop
    /// 1.SellStop
    /// </summary>
    public int AtrStop
    {
        get; set;
    }
    /// <summary>
    /// -1.bearish
    /// 1.bullish
    /// </summary>
    public int SuperTrend
    {
        get; set;
    }
}