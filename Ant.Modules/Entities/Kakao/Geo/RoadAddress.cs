using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao.Geo;

public struct RoadAddress
{
    [DataMember, JsonProperty("address_name")]
    public string Name
    {
        get; set;
    }
    [DataMember, JsonProperty("region_1depth_name")]
    public string RegionName1
    {
        get; set;
    }
    [DataMember, JsonProperty("region_2depth_name")]
    public string RegionName2
    {
        get; set;
    }
    [DataMember, JsonProperty("region_3depth_name")]
    public string RegionName3
    {
        get; set;
    }
    [DataMember, JsonProperty("road_name")]
    public string RoadName
    {
        get; set;
    }
    [DataMember, JsonProperty("underground_yn")]
    public string Underground
    {
        get; set;
    }
    [DataMember, JsonProperty("main_building_no")]
    public string MainBuildingNumber
    {
        get; set;
    }
    [DataMember, JsonProperty("sub_building_no")]
    public string SubBuildingNumber
    {
        get; set;
    }
    [DataMember, JsonProperty("building_name")]
    public string BuildingName
    {
        get; set;
    }
    [DataMember, JsonProperty("zone_no")]
    public string ZoneNumber
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
}