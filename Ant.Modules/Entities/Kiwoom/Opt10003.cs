using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

/// <summary>체결정보</summary>
public class Opt10003 : MultiOpt10003
{
    [StringLength(8), Key]
    public string? Date
    {
        get; set;
    }

    [DataMember, JsonProperty("종목코드"), StringLength(8), Key]
    public string Code
    {
        get => code ?? string.Empty;

        set => code = 'A' == value[0] ? value[1..] : value;
    }

    string? code;
}