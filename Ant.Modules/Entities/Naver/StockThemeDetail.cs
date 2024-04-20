using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities;

public class StockThemeDetail
{
    [StringLength(8), Key]
    public string? ThemeCode
    {
        get; set;
    }

    [StringLength(8), Key]
    public string? StockCode
    {
        get; set;
    }

    [StringLength(8)]
    public string? Date
    {
        get; set;
    }

    [StringLength(2)]
    public string? MarketClassification
    {
        get; set;
    }

    [StringLength(0x200)]
    public string? Description
    {
        get; set;
    }

    [NotMapped]
    public string? ThemeName
    {
        get; set;
    }
}