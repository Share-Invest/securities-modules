using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Assets;

public class AccOPW00005 : SingleOpw00005, IAccountBook
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
    long lookup;
}