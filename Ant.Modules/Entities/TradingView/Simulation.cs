using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities.TradingView;

public class Simulation
{
    [StringLength(0x10), Key, Column(Order = 1)]
    public string? Strategics
    {
        get; set;
    }
    [StringLength(0x10), Key, Column(Order = 3)]
    public string? Date
    {
        get; set;
    }
    [StringLength(8), Key, Column(Order = 2)]
    public string? Code
    {
        get; set;
    }
    [NotMapped]
    public DateTime DateTime
    {
        get; set;
    }
    [NotMapped]
    public double CurrentPrice
    {
        get; set;
    }
    [NotMapped]
    public double PurchasePrice
    {
        get; set;
    }
    [NotMapped]
    public int HoldingQuantity
    {
        get; set;
    }
    [Column(Order = 4)]
    public long CumulativeRevenue
    {
        get; set;
    }
}