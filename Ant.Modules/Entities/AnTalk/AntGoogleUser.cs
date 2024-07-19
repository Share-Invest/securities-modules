using Newtonsoft.Json;

using ShareInvest.Entities.Google;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Entities.AnTalk;

public class AntGoogleUser : GoogleUser
{
    [DataMember, JsonProperty("auth_code"), JsonPropertyName("auth_code")]
    public string? AuthCode
    {
        get; set;
    }

    [DataMember, JsonProperty("access_token"), JsonPropertyName("access_token")]
    public string? AccessToken
    {
        get; set;
    }

    [DataMember, JsonProperty("id_token"), JsonPropertyName("id_token")]
    public string? IdToken
    {
        get; set;
    }
}