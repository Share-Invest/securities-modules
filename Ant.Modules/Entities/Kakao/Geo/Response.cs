using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao.Geo;

public struct Response
{
    [DataMember, JsonProperty("address_name")]
    public string Name
    {
        get; set;
    }
    [DataMember, JsonProperty("address_type")]
    public string Type
    {
        get; set;
    }
    [DataMember, JsonProperty("x")]
    public string Longitude
    {
        get; set;
    }
    [DataMember, JsonProperty("y")]
    public string Latitude
    {
        get; set;
    }
    [DataMember, JsonProperty("address")]
    public Address Address
    {
        get; set;
    }
    [DataMember, JsonProperty("road_address")]
    public RoadAddress Road
    {
        get; set;
    }
}