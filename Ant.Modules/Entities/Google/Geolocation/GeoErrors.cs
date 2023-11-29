using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Geolocation;

public struct GeoErrors
{
    [DataMember, JsonProperty("domain")]
    public string Domain
    {
        get; set;
    }
    [DataMember, JsonProperty("reason")]
    public string Reason
    {
        get; set;
    }
    [DataMember, JsonProperty("message")]
    public string Message
    {
        get; set;
    }
}