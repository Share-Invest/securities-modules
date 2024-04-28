using ShareInvest.Entities.Analysis;

namespace ShareInvest.Entities;

public class Analytics : ActualValue
{
    public double EstimatedSales
    {
        get; set;
    }

    public double EstimatedOperatingProfit
    {
        get; set;
    }

    public double EstimatedNetProfit
    {
        get; set;
    }

    public double EstimatedPer
    {
        get; set;
    }

    public double EstimatedPbr
    {
        get; set;
    }

    public double EstimatedRoe
    {
        get; set;
    }

    public double MarketCap
    {
        get; set;
    }

    public string? EstimatedDate
    {
        get; set;
    }

    public string? Code
    {
        get; set;
    }

    public string? Name
    {
        get; set;
    }
}