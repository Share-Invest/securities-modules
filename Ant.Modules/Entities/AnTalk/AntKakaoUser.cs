using Newtonsoft.Json;

using ShareInvest.Entities.Kakao;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.AnTalk;

public class AntKakaoUser : KakaoUser
{
    [DataMember, JsonProperty("token_type")]
    public string? TokenType
    {
        get; set;
    }
    [DataMember, JsonProperty("access_token")]
    public string? AccessToken
    {
        get; set;
    }
    [DataMember, JsonProperty("refresh_token")]
    public string? RefreshToken
    {
        get; set;
    }
    [DataMember, JsonProperty("expires_at")]
    public DateTime ExpiresAtTime
    {
        get; set;
    }
}