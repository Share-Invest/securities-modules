using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities.TradingView;

public class FuturesBalance
{
    [StringLength(0x10), Required, Column(Order = 1)]
    public string? Date
    {
        get; set;
    }
    [StringLength(8), Key]
    public string? Code
    {
        get; set;
    }
    public double CurrentPrice
    {
        get; set;
    }
    public double PurchasePrice
    {
        get; set;
    }
    public int HoldingQuantity
    {
        get; set;
    }
    public long CumulativeRevenue
    {
        get; set;
    }
}