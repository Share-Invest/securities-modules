using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Maps;

public struct DistanceFromCenter
{
    [DataMember, JsonProperty("farthest")]
    public double Farthest
    {
        get; set;
    }
    [DataMember, JsonProperty("nearest")]
    public double Nearest
    {
        get; set;
    }
}