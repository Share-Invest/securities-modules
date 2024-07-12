using Newtonsoft.Json;

using ShareInvest.Entities.Kakao;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Entities.AnTalk;

public class AntKakaoUser : KakaoUser
{
    [DataMember, JsonProperty("token_type"), JsonPropertyName("token_type")]
    public string? TokenType
    {
        get; set;
    }

    [DataMember, JsonProperty("access_token"), JsonPropertyName("access_token")]
    public string? AccessToken
    {
        get; set;
    }

    [DataMember, JsonProperty("refresh_token"), JsonPropertyName("refresh_token")]
    public string? RefreshToken
    {
        get; set;
    }

    [DataMember, JsonProperty("id_token"), JsonPropertyName("id_token")]
    public string? IdToken
    {
        get; set;
    }

    [DataMember, JsonProperty("refresh_token_expires_at"), JsonPropertyName("refresh_token_expires_at")]
    public DateTime RefreshTokenExpiresAt
    {
        get; set;
    }

    [DataMember, JsonProperty("expires_at"), JsonPropertyName("expires_at")]
    public DateTime ExpiresAtTime
    {
        get; set;
    }
}