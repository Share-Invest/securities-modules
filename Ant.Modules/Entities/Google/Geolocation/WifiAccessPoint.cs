using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Geolocation;

public struct WifiAccessPoint
{
    [JsonProperty("macAddress"), DataMember]
    public string MacAddress
    {
        get; set;
    }
    [JsonProperty("signalStrength"), DataMember]
    public double SignalStrength
    {
        get; set;
    }
    [JsonProperty("signalToNoiseRatio"), DataMember]
    public double SignalToNoiseRatio
    {
        get; set;
    }
}