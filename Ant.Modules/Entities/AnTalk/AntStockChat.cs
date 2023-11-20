using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.AnTalk;

public class AntStockChat : AntChat
{
    [StringLength(8), Key]
    public string? Code
    {
        get; set;
    }
    [StringLength(0x100), Required]
    public string? Message
    {
        get; set;
    }
}