using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities;

public class StockTheme
{
    [StringLength(8), Key]
    public string? ThemeCode
    {
        get; set;
    }
    [StringLength(0x20)]
    public string? ThemeName
    {
        get; set;
    }
    [Key]
    public long Ticks
    {
        get; set;
    }
    [StringLength(8)]
    public string? RateCompareToPreviousDay
    {
        get; set;
    }
    [StringLength(8)]
    public string? AverageRateLastThreeDays
    {
        get; set;
    }
    [StringLength(4)]
    public string? RisingStockCount
    {
        get; set;
    }
    [StringLength(4)]
    public string? FlatStockCount
    {
        get; set;
    }
    [StringLength(4)]
    public string? FallingStockCount
    {
        get; set;
    }
    [NotMapped]
    public int TotalStockCount
    {
        get; set;
    }
    [NotMapped, StringLength(8)]
    public string? FirstLeadingStockCode
    {
        get; set;
    }
    [NotMapped, StringLength(8)]
    public string? SecondLeadingStockCode
    {
        get; set;
    }
    [NotMapped]
    public IEnumerable<StockThemeDetail>? ThemeDetail
    {
        get; set;
    }
}