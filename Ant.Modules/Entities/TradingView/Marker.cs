using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities.TradingView;

public class Marker
{
    [Key, Column(Order = 3), StringLength(0x10)]
    public string? DateTime
    {
        get; set;
    }
    public bool LongPosition
    {
        get; set;
    }
    public bool Square
    {
        get; set;
    }
    public int Label
    {
        get; set;
    }
    [Key, StringLength(0x10), Column(Order = 1)]
    public string? Strategics
    {
        get; set;
    }
    [Key, StringLength(8), Column(Order = 2)]
    public string? Code
    {
        get; set;
    }
}