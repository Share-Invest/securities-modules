using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Ant;

public record Chart
{
    [DataMember, JsonProperty("date")]
    public string? DateTime
    {
        get; set;
    }
    public int Current
    {
        get; set;
    }
    public int High
    {
        get; set;
    }
    public int Low
    {
        get; set;
    }
    public int Start
    {
        get; set;
    }
    public long Volume
    {
        get; set;
    }
}