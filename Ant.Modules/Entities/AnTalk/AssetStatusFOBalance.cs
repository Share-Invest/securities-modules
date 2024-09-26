namespace ShareInvest.Entities.AnTalk;

/// <summary>선옵잔고현황정산가기준</summary>
public struct AssetStatusFOBalance
{
    public string Code
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public int Classification
    {
        get; set;
    }

    public int Quantity
    {
        get; set;
    }

    public double Current
    {
        get; set;
    }

    public long Ticks
    {
        get; set;
    }

    public long Contract
    {
        get; set;
    }

    public long Evaluation
    {
        get; set;
    }

    public double Purchase
    {
        get; set;
    }

    public double Rate
    {
        get; set;
    }
}