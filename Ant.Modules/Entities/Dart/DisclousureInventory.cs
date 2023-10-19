using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Dart;

public class DisclousureInventory
{
    [DataMember, JsonProperty("status")]
    public string? Status
    {
        get; set;
    }
    [DataMember, JsonProperty("message")]
    public string? Message
    {
        get; set;
    }
    [DataMember, JsonProperty("page_no")]
    public int PageNumber
    {
        get; set;
    }
    [DataMember, JsonProperty("page_count")]
    public int PageCount
    {
        get; set;
    }
    [DataMember, JsonProperty("total_count")]
    public int TotalCount
    {
        get; set;
    }
    [DataMember, JsonProperty("total_page")]
    public int TotalPage
    {
        get; set;
    }
    [DataMember, JsonProperty("list")]
    public Disclousure[]? Inventory
    {
        get; set;
    }
}