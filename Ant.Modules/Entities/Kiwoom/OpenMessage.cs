using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities.Kiwoom;

public class OpenMessage
{
    [Key, Column(Order = 1)]
    public long Lookup
    {
        set
        {
            lookup = value > Cache.Epoch ? value - Cache.Epoch : value;
        }
        get => lookup;
    }
    [Key, Column(Order = 2), StringLength(0x40)]
    public string? SerialKey
    {
        get; set;
    }
    [Required, StringLength(0x100)]
    public string Title
    {
        set
        {
            title = value.Length > 0 && value[^1] == '다' ? string.Concat(value, '.') : value;
        }
        get => title ?? string.Empty;
    }
    [Required, StringLength(0x20)]
    public string? Code
    {
        get; set;
    }
    [Required, StringLength(4)]
    public string? Screen
    {
        get; set;
    }
    long lookup;
    string? title;
}