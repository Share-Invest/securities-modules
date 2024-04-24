using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities.Analysis;

public class ResponseGrowthRateRank : GrowthRateRank
{
    [NotMapped]
    public int SalesChangeRank
    {
        get; set;
    }

    [NotMapped]
    public int OpChangeRank
    {
        get; set;
    }

    [NotMapped]
    public int NpChangeRank
    {
        get; set;
    }

    [NotMapped]
    public int MarketCapChangeRank
    {
        get; set;
    }

    [NotMapped]
    public StockThemeDetail[]? Theme
    {
        get; set;
    }

    [NotMapped]
    public int PerChangeRank
    {
        get; set;
    }

    [NotMapped]
    public int PbrChangeRank
    {
        get; set;
    }

    [NotMapped]
    public int RoeChangeRank
    {
        get; set;
    }
}