using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Assets;

public class BalOPW00005 : AccountBook
{
    [StringLength(0x10), DataMember, JsonProperty("계좌번호"), Key]
    public override string? AccNo
    {
        get; set;
    }
    [StringLength(10), Key]
    public override string? Date
    {
        get; set;
    }
    [Column(Order = 1)]
    public override long Lookup
    {
        set
        {
            lookup = value > Cache.Epoch ? value - Cache.Epoch : value;
        }
        get => lookup;
    }
    [StringLength(0x10), DataMember, JsonProperty("신용구분")]
    public string? Credit
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("대출일")]
    public string? LoanDate
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("만기일")]
    public string? ExpiryDate
    {
        get; set;
    }
    [StringLength(0x8), DataMember, JsonProperty("종목번호"), Key]
    public string Code
    {
        get => code ?? string.Empty;

        set => code = value.Length > 0 && 'A' == value[0] ? value[1..] : value;
    }
    [StringLength(0x10), DataMember, JsonProperty("종목명")]
    public string? Name
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("결제잔고")]
    public string? PaymentBalance
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("현재잔고")]
    public string? Quantity
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("현재가")]
    public string? Current
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("매입단가")]
    public string? Average
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("매입금액")]
    public string? Purchase
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("평가금액")]
    public string? Evaluation
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("평가손익")]
    public string? Amount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("손익률")]
    public string? Rate
    {
        get; set;
    }
    string? code;
}