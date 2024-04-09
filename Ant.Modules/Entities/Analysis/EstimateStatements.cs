namespace ShareInvest.Entities.Analysis;

public struct EstimateStatements
{
    public string Date
    {
        get; set;
    }

    public double Sales
    {
        get; set;
    }

    public double SalesGrowthRate
    {
        get; set;
    }

    public double OperatingProfit
    {
        get; set;
    }

    public double OpGrowthRate
    {
        get; set;
    }

    public double NetProfit
    {
        get; set;
    }

    public double NpGrowthRate
    {
        get; set;
    }
}