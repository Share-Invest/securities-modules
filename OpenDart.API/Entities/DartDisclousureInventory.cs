using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities;

public class DartDisclousureInventory
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
    public DartDisclousure[]? Inventory
    {
        get; set;
    }
}