using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

/// <summary>선옵체결추이</summary>
public class OPT50006 : MultiOPT50006
{
    [StringLength(8), Key]
    public string? Date
    {
        get; set;
    }

    [DataMember, JsonProperty("종목코드"), StringLength(8), Key]
    public string? Code
    {
        get; set;
    }

    [DataMember, JsonProperty("종목명"), NotMapped]
    public string? Name
    {
        get; set;
    }
}