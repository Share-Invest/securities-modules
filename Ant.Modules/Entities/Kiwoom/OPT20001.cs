using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class OPT20001 : SingleOpt20001
{
    [DataMember, JsonProperty("업종코드"), Key, StringLength(4)]
    public string? Code
    {
        get; set;
    }

    [DataMember, JsonProperty("시장구분"), StringLength(2)]
    public string? MarketClassification
    {
        get; set;
    }

    [StringLength(8), Key]
    public string? Date
    {
        get; set;
    }
}