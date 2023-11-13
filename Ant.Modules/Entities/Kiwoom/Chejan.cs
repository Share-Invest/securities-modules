using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class Chejan
{
    [DataMember, StringLength(0x10), JsonProperty("계좌번호"), Key]
    public virtual string? AccNo
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("종목명")]
    public virtual string? Name
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("현재가")]
    public virtual string? CurrentPrice
    {
        get; set;
    }
    [StringLength(10), Key]
    public virtual string? Date
    {
        get; set;
    }
    [Column(Order = 1), Key]
    public virtual long Lookup
    {
        set
        {
            lookup = value > Cache.Epoch ? value - Cache.Epoch : value;
        }
        get => lookup;
    }
    [DataMember, JsonProperty("종목코드_업종코드"), StringLength(8), Key]
    public virtual string Code
    {
        get => code ?? string.Empty;

        set => code = 'A' == value[0] ? value[1..] : value;
    }
    long lookup;
    string? code;
}