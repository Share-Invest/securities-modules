using Skender.Stock.Indicators;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities;

public class Indicators
{
    [Key, StringLength(0x10)]
    public string? Strategics
    {
        get; set;
    }
    [Column(Order = 1)]
    public long SeedMoney
    {
        get; set;
    }
    public int SlopeTakeCount
    {
        get; set;
    }
    public int HistogramTakeCount
    {
        get; set;
    }
    [NotMapped]
    public IEnumerable<MacdResult>? Macd
    {
        get; set;
    }
    [NotMapped]
    public IEnumerable<SlopeResult>? Slope
    {
        get; set;
    }
    [NotMapped]
    public IEnumerable<SuperTrendResult>? SuperTrend
    {
        get; set;
    }
    [NotMapped]
    public IEnumerable<AtrStopResult>? AtrStop
    {
        get; set;
    }
}