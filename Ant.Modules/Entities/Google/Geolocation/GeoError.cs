using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Geolocation;

public struct GeoError
{
    [DataMember, JsonProperty("code")]
    public int Code
    {
        get; set;
    }
    [DataMember, JsonProperty("message")]
    public string Message
    {
        get; set;
    }
    [DataMember, JsonProperty("errors")]
    public GeoErrors[] Errors
    {
        get; set;
    }
}