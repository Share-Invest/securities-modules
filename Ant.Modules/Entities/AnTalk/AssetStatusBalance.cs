namespace ShareInvest.Entities.AnTalk;

public struct AssetStatusBalance
{
    public string Code
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public int Quantity
    {
        get; set;
    }
    public int Average
    {
        get; set;
    }
    public int Current
    {
        get; set;
    }
    public long Ticks
    {
        get; set;
    }
    public long Valuation
    {
        get; set;
    }
    public long Purchase
    {
        get; set;
    }
    public double Rate
    {
        get; set;
    }
}