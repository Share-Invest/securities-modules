using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities.TradingView;

public class Simulation
{
    [StringLength(0x10), Key]
    public string? Date
    {
        get; set;
    }
    [StringLength(8), Key]
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
    [Required]
    public long CumulativeRevenue
    {
        get; set;
    }
}