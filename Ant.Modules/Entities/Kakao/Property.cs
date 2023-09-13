using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao;

public class Property
{
    [DataMember, JsonProperty("nickname")]
    public string? Name
    {
        get; set;
    }
    [DataMember, JsonProperty("profile_image")]
    public string? Image
    {
        get; set;
    }
    [DataMember, JsonProperty("thumbnail_image")]
    public string? Thumbnail
    {
        get; set;
    }
}