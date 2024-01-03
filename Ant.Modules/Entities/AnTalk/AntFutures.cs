namespace ShareInvest.Entities.AnTalk;

public struct AntFutures
{
    public string Code
    {
        get; set;
    }
    public string Date
    {
        get; set;
    }
    public string Name
    {
        get; set;
    }
    public string RemainingDays
    {
        get; set;
    }
    public string RemainingDaysBasedOnBusinessDays
    {
        get; set;
    }
    public string[] DateArr
    {
        get; set;
    }
}