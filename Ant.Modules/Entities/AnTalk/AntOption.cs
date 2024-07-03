namespace ShareInvest.Entities.AnTalk;

public struct AntOption
{
    public string Code
    {
        get; set;
    }

    public double CurrentPrice
    {
        get; set;
    }

    public int CompareToPreviousSign
    {
        get; set;
    }

    public double CompareToPreviousDay
    {
        get; set;
    }

    public double Rate
    {
        get; set;
    }

    public int Volume
    {
        get; set;
    }

    public double TheoryPrice
    {
        get; set;
    }
}