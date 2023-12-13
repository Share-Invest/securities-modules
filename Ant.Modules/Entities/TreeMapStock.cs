namespace ShareInvest.Entities;

public class TreeMapStock
{
    public string? Code
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }
    public string[]? ThemeCode
    {
        get; set;
    }
    public double Rate
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
    public long PreviousTradingVolume
    {
        get; set;
    }
    public long NumberOfListedStocks
    {
        get; set;
    }
}