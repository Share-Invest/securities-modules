using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Entities.Identity;

public class DeviceIdentity
{
    [DataMember, JsonProperty("device_id"), JsonPropertyName("device_id")]
    public string? DeviceId
    {
        get; set;
    }
}