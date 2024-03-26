using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities;

public class FinancialStatements
{
    [DataMember, JsonProperty("YYMM"), StringLength(8)]
    public string? Date
    {
        set
        {
            date = value?[..7].Replace('.', '-');
        }
        get => date;
    }

    [DataMember, JsonProperty("YYMM")]
    public bool Estimated
    {
        set
        {
            estimated = date?[^2] == 'E';
        }
        get => estimated;
    }

    [DataMember, JsonProperty("SALES"), StringLength(0x10)]
    public string? Sales
    {
        get; set;
    }

    [DataMember, JsonProperty("YOY"), StringLength(8)]
    public string? YearOnYear
    {
        get; set;
    }

    [DataMember, JsonProperty("OP"), StringLength(0x10)]
    public string? OperatingProfit
    {
        get; set;
    }

    [DataMember, JsonProperty("NP"), StringLength(0x10)]
    public string? NetProfit
    {
        get; set;
    }

    [DataMember, JsonProperty(nameof(EPS)), StringLength(0x10)]
    public string? EPS
    {
        get; set;
    }

    [DataMember, JsonProperty(nameof(BPS)), StringLength(0x10)]
    public string? BPS
    {
        get; set;
    }

    [DataMember, JsonProperty(nameof(PER)), StringLength(8)]
    public string? PER
    {
        get; set;
    }

    [DataMember, JsonProperty(nameof(PBR)), StringLength(8)]
    public string? PBR
    {
        get; set;
    }

    [DataMember, JsonProperty(nameof(ROE)), StringLength(8)]
    public string? ROE
    {
        get; set;
    }

    [DataMember, JsonProperty(nameof(EV)), StringLength(8)]
    public string? EV
    {
        get; set;
    }

    [DataMember, JsonProperty("MAIN"), StringLength(8)]
    public string? Main
    {
        get; set;
    }

    [DataMember, JsonProperty("TOT_ROW")]
    public int Row
    {
        get; set;
    }

    [DataMember, JsonProperty("code"), Key]
    public string? Code
    {
        get; set;
    }

    string? date;
    bool estimated;
}