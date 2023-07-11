using Microsoft.ML.Data;

namespace ShareInvest.Models;

public class InputConditionData
{
    [LoadColumn(0)]
    public double[]? DateTimes
    {
        get; set;
    }
    [LoadColumn(1)]
    public double[]? OpenPrices
    {
        get; set;
    }
    [LoadColumn(2)]
    public double[]? HighPrices
    {
        get; set;
    }
    [LoadColumn(3)]
    public double[]? LowPrices
    {
        get; set;
    }
    [LoadColumn(4)]
    public double[]? ClosePrices
    {
        get; set;
    }
    [LoadColumn(5)]
    public double[]? Volumes
    {
        get; set;
    }
    [LoadColumn(6)]
    public bool Satisfy
    {
        get; set;
    }
}