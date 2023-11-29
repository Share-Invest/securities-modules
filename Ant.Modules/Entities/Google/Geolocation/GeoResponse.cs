using Newtonsoft.Json;

using ShareInvest.Entities.Google.Maps;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Geolocation;

public struct GeoResponse
{
    [DataMember, JsonProperty("accuracy")]
    public double Accuracy
    {
        get; set;
    }
    [DataMember, JsonProperty("location")]
    public Coordinate Coordinate
    {
        get; set;
    }
    [DataMember, JsonProperty("error")]
    public GeoError Error
    {
        get; set;
    }
}