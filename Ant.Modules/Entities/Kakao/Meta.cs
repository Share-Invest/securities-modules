using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kakao;

public struct Meta
{
    [DataMember, JsonProperty("total_count")]
    public int Total
    {
        get; set;
    }
    [DataMember, JsonProperty("pageable_count")]
    public int PageableCount
    {
        get; set;
    }
    [DataMember, JsonProperty("is_end")]
    public bool IsEnd
    {
        get; set;
    }
}