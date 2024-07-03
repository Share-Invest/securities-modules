using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class OPT50019 : SingleOPT50019
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