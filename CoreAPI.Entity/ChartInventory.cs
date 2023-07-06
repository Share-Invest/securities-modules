using Newtonsoft.Json;

using ShareInvest.Ant;

using System.Runtime.Serialization;

namespace ShareInvest;

public record ChartInventory
{
    [DataMember, JsonProperty("chart")]
    public Chart[]? Charts
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }
    public string? Code
    {
        get; set;
    }
}