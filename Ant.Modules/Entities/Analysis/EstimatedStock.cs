namespace ShareInvest.Entities.Analysis;

public struct EstimatedStock
{
    public string Code
    {
        get; set;
    }

    public IEnumerable<Tuple<string, DateTime>> Dates
    {
        get; set;
    }
}