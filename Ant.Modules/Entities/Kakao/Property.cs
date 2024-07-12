using Newtonsoft.Json;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Entities.Kakao;

public class Property
{
    [DataMember, JsonProperty("nick_name"), JsonPropertyName("nick_name")]
    public string? Name
    {
        get; set;
    }

    [DataMember, JsonProperty("profile_image"), JsonPropertyName("profile_image")]
    public string? Image
    {
        get; set;
    }

    [DataMember, JsonProperty("thumbnail_image"), JsonPropertyName("thumbnail_image")]
    public string? Thumbnail
    {
        get; set;
    }
}