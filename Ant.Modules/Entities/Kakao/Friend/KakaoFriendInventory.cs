using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao;

public struct KakaoFriendInventory
{
    [DataMember, JsonProperty("elements")]
    public IEnumerable<KakaoFriend> Friends
    {
        get; set;
    }
    [DataMember, JsonProperty("total_count")]
    public int Count
    {
        get; set;
    }
    [DataMember, JsonProperty("user_id")]
    public string? UserId
    {
        get; set;
    }
    [NotMapped]
    public DateTime RegisteredTime
    {
        get; set;
    }
}