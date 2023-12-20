using Newtonsoft.Json;

using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class Opt10080 : MultiOpt10080
{
    [NotMapped]
    public string? Name
    {
        get; set;
    }
    [StringLength(8)]
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