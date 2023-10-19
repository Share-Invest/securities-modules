using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Assets;

public class BalOPW00004 : AccountBook
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
    [DataMember, JsonProperty("종목코드"), StringLength(8), Key]
    public string Code
    {
        get => code ?? string.Empty;

        set => code = value[0].Equals('A') ? value[1..] : value;
    }
    [DataMember, JsonProperty("종목명"), StringLength(0x10)]
    public string? Name
    {
        get; set;
    }
    [DataMember, JsonProperty("보유수량"), StringLength(0x10)]
    public string? Quantity
    {
        get; set;
    }
    [DataMember, JsonProperty("평균단가"), StringLength(0x10)]
    public string? Average
    {
        get; set;
    }
    [DataMember, JsonProperty("현재가"), StringLength(0x10)]
    public string? Current
    {
        get; set;
    }
    [DataMember, JsonProperty("평가금액"), StringLength(0x10)]
    public string? Evaluation
    {
        get; set;
    }
    [DataMember, JsonProperty("손익금액"), StringLength(0x10)]
    public string? Amount
    {
        get; set;
    }
    [DataMember, JsonProperty("손익율"), StringLength(0x10)]
    public string? Rate
    {
        get; set;
    }
    [DataMember, JsonProperty("대출일"), StringLength(0x10)]
    public string? Loan
    {
        get; set;
    }
    [DataMember, JsonProperty("매입금액"), StringLength(0x10)]
    public string? Purchase
    {
        get; set;
    }
    [DataMember, JsonProperty("결제잔고"), StringLength(0x10)]
    public string? PaymentBalance
    {
        get; set;
    }
    [DataMember, JsonProperty("전일매수수량"), StringLength(0x10)]
    public string? PreviousPurchaseQuantity
    {
        get; set;
    }
    [DataMember, JsonProperty("전일매도수량"), StringLength(0x10)]
    public string? PreviousSalesQuantity
    {
        get; set;
    }
    [DataMember, JsonProperty("금일매수수량"), StringLength(0x10)]
    public string? PurchaseQuantity
    {
        get; set;
    }
    [DataMember, JsonProperty("금일매도수량"), StringLength(0x10)]
    public string? SalesQuantity
    {
        get; set;
    }
    string? code;
}