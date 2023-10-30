using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Assets;

public class BalOPW00005 : MultiOpw00005, IAccountBook
{
    [StringLength(0x10), DataMember, JsonProperty("계좌번호"), Key]
    public string? AccNo
    {
        get; set;
    }
    [StringLength(10), Key]
    public string? Date
    {
        get; set;
    }
    [Column(Order = 1)]
    public long Lookup
    {
        set
        {
            lookup = value > Cache.Epoch ? value - Cache.Epoch : value;
        }
        get => lookup;
    }
    [StringLength(0x8), DataMember, JsonProperty("종목번호"), Key]
    public override string? Code
    {
        get => code ?? string.Empty;

        set => code = value?.Length > 0 && 'A' == value[0] ? value[1..] : value;
    }
    string? code;
    long lookup;
}