namespace ShareInvest.Entities;

public struct TreeMapStock
{
    public string Code
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public Dictionary<string, string> ThemeInventory
    {
        get; set;
    }
    public double RateCompareToPreviousDay
    {
        get; set;
    }
    public int Price
    {
        get; set;
    }
    public int CompareToPreviousSign
    {
        get; set;
    }
    public int CompareToPreviousDay
    {
        get; set;
    }
    public long Volume
    {
        get; set;
    }
    public double PreviousTradingVolume
    {
        get; set;
    }
    public long NumberOfListedStocks
    {
        get; set;
    }
}