using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Geolocation;

public class GeoRequest
{
    [JsonProperty("considerIp"), DataMember]
    public bool ConsiderIp
    {
        get; set;
    }
    [JsonProperty("wifiAccessPoints"), DataMember]
    public WifiAccessPoint[]? WifiAccessPoints
    {
        get; set;
    }
}