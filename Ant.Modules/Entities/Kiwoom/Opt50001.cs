using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class Opt50001 : SingleOpt50001
{
    [StringLength(8), Key, DataMember, JsonProperty("종목코드")]
    public string? Code
    {
        get; set;
    }
    [StringLength(8), Key]
    public string? Date
    {
        get; set;
    }
}