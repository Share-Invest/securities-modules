using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class Opt50029 : MultiOpt50029
{
    [StringLength(8), Key, DataMember, JsonProperty("종목코드")]
    public string? Code
    {
        get; set;
    }
    [StringLength(8), Column(Order = 1)]
    public string? Date
    {
        get => Time?[..8];
    }
}