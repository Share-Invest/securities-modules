namespace ShareInvest.Entities.AnTalk;

public struct AntStock
{
    public string Code
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string ListingDate
    {
        get; set;
    }
    public int Current
    {
        get; set;
    }
    public int StockPrice
    {
        get; set;
    }
    public double Rate
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
    public long TransactionAmount
    {
        get; set;
    }
    public long NumberOfListedStocks
    {
        get; set;
    }
}