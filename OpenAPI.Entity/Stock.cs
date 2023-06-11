namespace ShareInvest;

public class Stock
{
    public virtual string? Code
    {
        get; set;
    }
    public virtual string? Name
    {
        get; set;
    }
    public virtual string? CurrentPrice
    {
        get; set;
    }
    public virtual string? Rate
    {
        get; set;
    }
    public virtual string? CompareToPreviousSign
    {
        get; set;
    }
    public virtual string? CompareToPreviousDay
    {
        get; set;
    }
    public virtual string? Volume
    {
        get; set;
    }
    public virtual string? TransactionAmount
    {
        get; set;
    }
    public virtual string? State
    {
        get; set;
    }
}