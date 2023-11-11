using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Firebase;

public struct AntUserLoginInfo
{
    [DataMember, JsonProperty("token")]
    public string FCMToken
    {
        get; set;
    }
    [DataMember, JsonProperty("provider")]
    public string LoginProvider
    {
        get; set;
    }
    [DataMember, JsonProperty("id")]
    public string ProviderKey
    {
        get; set;
    }
}