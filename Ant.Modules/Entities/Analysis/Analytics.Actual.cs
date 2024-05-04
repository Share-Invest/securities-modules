namespace ShareInvest.Entities.Analysis;

public class ActualValue
{
    public double ActualSales
    {
        get; set;
    }

    public double ActualOperatingProfit
    {
        get; set;
    }

    public double ActualNetProfit
    {
        get; set;
    }

    public double ActualPer
    {
        get; set;
    }

    public double ActualPbr
    {
        get; set;
    }

    public double ActualRoe
    {
        get; set;
    }

    public string? ActualDate
    {
        get; set;
    }

    public AnalyticsStock Quotes
    {
        get; set;
    }
}