using ShareInvest.Services.AnTalk;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities.AnTalk;

public class AntChat
{
    [NotMapped]
    public DateTime DateTime
    {
        get; set;
    }
    [NotMapped]
    public string? Image
    {
        get; set;
    }
    [NotMapped]
    public string? Name
    {
        get; set;
    }
    [StringLength(0x40)]
    public string? UserId
    {
        get; set;
    }
    [NotMapped]
    public bool IsMyself
    {
        get; set;
    }
    [Column(Order = 1), Key]
    public long Lookup
    {
        set
        {
            lookup = value > Cache.Epoch ? value - Cache.Epoch : value;
        }
        get => lookup;
    }
    [Required]
    public MessageType Type
    {
        get; set;
    }
    long lookup;
}