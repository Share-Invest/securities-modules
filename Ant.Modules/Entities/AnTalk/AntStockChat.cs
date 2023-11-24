using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    [NotMapped]
    public string? AccessToken
    {
        set
        {
            accessToken = value?.Replace("Bearer", string.Empty, StringComparison.OrdinalIgnoreCase).Trim();
        }
        get => accessToken;
    }
    string? accessToken;
}