using Newtonsoft.Json;

using ShareInvest.Entities.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Entities.Kakao;

public class KakaoUser : DeviceIdentity
{
    [DatabaseGenerated(DatabaseGeneratedOption.None), DataMember, JsonProperty("id"), Key]
    public long Id
    {
        get; set;
    }

    [DataMember, JsonProperty("connected_at"), JsonPropertyName("connected_at")]
    public DateTime ConnectedAt
    {
        get; set;
    }

    [DataMember, JsonProperty("properties"), JsonPropertyName("properties")]
    public Property? Profile
    {
        get; set;
    }

    [DataMember, JsonProperty("kakao_account"), JsonPropertyName("kakao_account")]
    public Account? Account
    {
        get; set;
    }
}