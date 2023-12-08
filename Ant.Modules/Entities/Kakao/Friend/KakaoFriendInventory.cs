using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao;

public struct KakaoFriendInventory
{
    [DataMember, JsonProperty("elements")]
    public IEnumerable<KakaoFriend> Friends
    {
        get; set;
    }
    [DataMember, JsonProperty("totalCount")]
    public int Count
    {
        get; set;
    }
    [DataMember, JsonProperty("userId")]
    public string? UserId
    {
        get; set;
    }
}