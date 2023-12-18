namespace ShareInvest.Entities.TradingView;

public struct OverviewCandleChart
{
    public string Date
    {
        get; set;
    }
    public int Open
    {
        get; set;
    }
    public int High
    {
        get; set;
    }
    public int Low
    {
        get; set;
    }
    public int Close
    {
        get; set;
    }
    public long Volume
    {
        get; set;
    }
}