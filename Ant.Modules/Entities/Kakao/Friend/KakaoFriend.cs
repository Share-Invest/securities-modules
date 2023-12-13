using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao;

public class KakaoFriend
{
    [DataMember, JsonProperty("id"), StringLength(0x10), Key]
    public string? Id
    {
        get; set;
    }
    [StringLength(0x30), JsonProperty("user_id"), Key]
    public string? UserId
    {
        get; set;
    }
    [DataMember, JsonProperty("uuid"), StringLength(0x20)]
    public string? Uuid
    {
        get; set;
    }
    [DataMember, JsonProperty("profile_nickname"), StringLength(0x10)]
    public string? NickName
    {
        get; set;
    }
    [DataMember, JsonProperty("profile_thumbnail_image"), StringLength(0x80)]
    public string? Image
    {
        get; set;
    }
    [DataMember, JsonProperty("favorite")]
    public bool Favorite
    {
        get; set;
    }
    [DataMember, JsonProperty("allowed_msg")]
    public bool AllowedMsg
    {
        get; set;
    }
    public long RegisteredTicks
    {
        set
        {
            lookup = value > Cache.Epoch ? value - Cache.Epoch : value;
        }
        get => lookup;
    }
    long lookup;
}