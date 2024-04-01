namespace ShareInvest.Entities.Analysis;

public struct ActualStatements
{
    public string Code
    {
        get; set;
    }

    public string Date
    {
        get; set;
    }

    public double Sales
    {
        get; set;
    }

    public double OperatingProfit
    {
        get; set;
    }

    public double NetProfit
    {
        get; set;
    }
}