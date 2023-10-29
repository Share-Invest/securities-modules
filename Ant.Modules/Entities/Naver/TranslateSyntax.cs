using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Naver;

public struct TranslateSyntax
{
    [DataMember, JsonProperty("@type")]
    public string Type
    {
        get; set;
    }
    [DataMember, JsonProperty("@service")]
    public string Service
    {
        get; set;
    }
    [DataMember, JsonProperty("@version")]
    public string Version
    {
        get; set;
    }
    [DataMember, JsonProperty("result")]
    public TranslateResult Result
    {
        get; set;
    }
}