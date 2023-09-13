using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao;

public class Profile
{
    [JsonProperty("thumbnail_image_url"), DataMember]
    public string? Thumbnail
    {
        get; set;
    }
    [JsonProperty("profile_image_url"), DataMember]
    public string? Image
    {
        get; set;
    }
    [JsonProperty("is_default_image"), DataMember]
    public bool IsDefault
    {
        get; set;
    }
    [JsonProperty("nickname"), DataMember]
    public string? Name
    {
        get; set;
    }
}