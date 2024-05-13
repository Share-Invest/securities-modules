namespace ShareInvest.Entities.Analysis;

public struct NormalizeFinancialState
{
    public int NormalizeRevenue
    {
        get; set;
    }

    public int NormalizeOp
    {
        get; set;
    }

    public int NormalizeNp
    {
        get; set;
    }

    public string Revenue
    {
        get; set;
    }

    public string Op
    {
        get; set;
    }

    public string Np
    {
        get; set;
    }

    public string RecordDate
    {
        get; set;
    }

    public string Date
    {
        get; set;
    }

    public bool Estimated
    {
        get; set;
    }
}