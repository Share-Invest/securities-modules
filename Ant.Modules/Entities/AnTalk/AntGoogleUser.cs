using Newtonsoft.Json;

using ShareInvest.Entities.Google;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.AnTalk;

public class AntGoogleUser : GoogleUser
{
    [DataMember, JsonProperty("server_auth_code")]
    public string? AuthCode
    {
        get; set;
    }
    [DataMember, JsonProperty("access_token")]
    public string? AccessToken
    {
        get; set;
    }
    [DataMember, JsonProperty("id_token")]
    public string? IdToken
    {
        get; set;
    }
}