using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao;

public class KakaoUser
{
    [DatabaseGenerated(DatabaseGeneratedOption.None), DataMember, JsonProperty("id"), Key]
    public long Id
    {
        get; set;
    }
    [DataMember, JsonProperty("connected_at")]
    public DateTime ConnectedAt
    {
        get; set;
    }
    [DataMember, JsonProperty("properties")]
    public Property? Profile
    {
        get; set;
    }
    [DataMember, JsonProperty("kakao_account")]
    public Account? Account
    {
        get; set;
    }
}