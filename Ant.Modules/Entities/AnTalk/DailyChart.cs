namespace ShareInvest.Entities.AnTalk;

public struct DailyChart
{
    public string Date
    {
        get; set;
    }
    public int Current
    {
        get; set;
    }
    public int High
    {
        get; set;
    }
    public int Low
    {
        get; set;
    }
    public int Start
    {
        get; set;
    }
    public long Volume
    {
        get; set;
    }
}