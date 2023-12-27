namespace ShareInvest.Utilities.TradingView;

public struct Series
{
    public bool Order
    {
        get; set;
    }
    public bool IsBullish
    {
        get; set;
    }
    public object ObjData
    {
        get; set;
    }
}