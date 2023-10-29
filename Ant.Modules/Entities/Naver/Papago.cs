using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Naver;

public struct Papago
{
    [DataMember, JsonProperty("message")]
    public TranslateSyntax TranslateSyntax
    {
        get; set;
    }
}