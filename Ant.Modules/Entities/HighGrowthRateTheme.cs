namespace ShareInvest.Entities;

public struct HighGrowthRateTheme
{
    public string Code
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public double AverageRateLastThreeDays
    {
        get; set;
    }
    public double RateCompareToPreviousDay
    {
        get; set;
    }
}