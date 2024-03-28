namespace ShareInvest.Entities.Analysis;

public struct EstimatedStock
{
    public string Code
    {
        get; set;
    }

    public IEnumerable<string> Dates
    {
        get; set;
    }
}