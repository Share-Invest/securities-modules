using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities;

public class FinancialStatements
{
    [DataMember, JsonProperty("YYMM"), NotMapped]
    public string? ReceiveDate
    {
        get; set;
    }

    [Key, StringLength(8)]
    public string? Date
    {
        get; set;
    }

    [Key]
    public bool Estimated
    {
        get; set;
    }

    [DataMember, JsonProperty("SALES"), StringLength(0x10)]
    public string? Sales
    {
        set
        {
            sales = value?.Replace(",", string.Empty);
        }
        get => sales;
    }
    string? sales;

    [DataMember, JsonProperty("YOY"), StringLength(8)]
    public string? YearOnYear
    {
        set
        {
            yoy = value?.Replace(",", string.Empty);
        }
        get => yoy;
    }
    string? yoy;

    [DataMember, JsonProperty("OP"), StringLength(0x10)]
    public string? OperatingProfit
    {
        set
        {
            op = value?.Replace(",", string.Empty);
        }
        get => op;
    }
    string? op;

    [DataMember, JsonProperty("NP"), StringLength(0x10)]
    public string? NetProfit
    {
        set
        {
            np = value?.Replace(",", string.Empty);
        }
        get => np;
    }
    string? np;

    [DataMember, JsonProperty(nameof(EPS)), StringLength(0x10)]
    public string? EPS
    {
        set
        {
            eps = value?.Replace(",", string.Empty);
        }
        get => eps;
    }
    string? eps;

    [DataMember, JsonProperty(nameof(BPS)), StringLength(0x10)]
    public string? BPS
    {
        set
        {
            bps = value?.Replace(",", string.Empty);
        }
        get => bps;
    }
    string? bps;

    [DataMember, JsonProperty(nameof(PER)), StringLength(8)]
    public string? PER
    {
        set
        {
            per = value?.Replace(",", string.Empty);
        }
        get => per;
    }
    string? per;

    [DataMember, JsonProperty(nameof(PBR)), StringLength(8)]
    public string? PBR
    {
        set
        {
            pbr = value?.Replace(",", string.Empty);
        }
        get => pbr;
    }
    string? pbr;

    [DataMember, JsonProperty(nameof(ROE)), StringLength(8)]
    public string? ROE
    {
        set
        {
            roe = value?.Replace(",", string.Empty);
        }
        get => roe;
    }
    string? roe;

    [DataMember, JsonProperty(nameof(EV)), StringLength(8)]
    public string? EV
    {
        set
        {
            ev = value?.Replace(",", string.Empty);
        }
        get => ev;
    }
    string? ev;

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

    [Key, StringLength(8)]
    public string? Code
    {
        get; set;
    }

    [Key, JsonIgnore]
    public DateTime RecordDate
    {
        get; set;
    }
}