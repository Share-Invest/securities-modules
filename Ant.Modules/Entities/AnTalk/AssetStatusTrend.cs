namespace ShareInvest.Entities.AnTalk;

public struct AssetStatusTrend
{
    public string Date
    {
        get; set;
    }
    public long Ticks
    {
        get; set;
    }
    public long Asset
    {
        get; set;
    }
    public long ComparedAsset
    {
        get; set;
    }
}