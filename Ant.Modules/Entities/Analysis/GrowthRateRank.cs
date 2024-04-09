using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities.Analysis;

public class GrowthRateRank
{
    [Key, StringLength(8)]
    public string? Code
    {
        get; set;
    }

    [Key, JsonIgnore, StringLength(0xA)]
    public string? RecordDate
    {
        get; set;
    }

    public int SalesRank
    {
        get; set;
    }

    public int OpRank
    {
        get; set;
    }

    public int NpRank
    {
        get; set;
    }

    [NotMapped]
    public string? Name
    {
        get; set;
    }

    [NotMapped]
    public int Rank
    {
        get; set;
    }
}