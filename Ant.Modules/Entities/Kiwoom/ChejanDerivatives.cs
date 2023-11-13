using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class ChejanDerivatives : Chejan
{
    [DataMember, StringLength(0x10), JsonProperty("예수금")]
    public string? Deposit
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("보유수량")]
    public string? HoldingQuantity
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("매입단가")]
    public string? PurchasePrice
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("총매입가")]
    public string? PurchaseAmount
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("주문가능수량")]
    public string? QuantityAvailableForOrder
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("당일순매수량")]
    public string? TransactionQuantity
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("매도_매수구분")]
    public string? OrderStatus
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("당일총매도손익")]
    public string? TradingProfit
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("매도호가")]
    public string? AskPrice
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("매수호가")]
    public string? BidPrice
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("기준가")]
    public string? BasePrice
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("손익율")]
    public string? Rate
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("파생상품거래단위")]
    public string? DerivativesTradingUnit
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("상한가")]
    public string? UpperLimitPrice
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("하한가")]
    public string? LowerLimitPrice
    {
        get; set;
    }
}