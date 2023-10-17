using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Maps;

public struct Coordinate
{
    [DataMember, JsonProperty("lat")]
    public double Lat
    {
        get; set;
    }
    [DataMember, JsonProperty("lng")]
    public double Lng
    {
        get; set;
    }
}