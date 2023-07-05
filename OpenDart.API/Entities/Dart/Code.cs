using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Dart;

public class Code
{
    [DataMember, JsonProperty("corp_code")]
    public virtual string? CorpCode
    {
        get; set;
    }
    [DataMember, JsonProperty("corp_name")]
    public virtual string? CorpName
    {
        get; set;
    }
    [DataMember, JsonProperty("modify_date")]
    public virtual string? ModifyDate
    {
        get; set;
    }
    [DataMember, JsonProperty("stock_code")]
    public virtual string? StockCode
    {
        get; set;
    }
}