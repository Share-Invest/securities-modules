using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class ChejanBalance : Chejan
{
    [DataMember, StringLength(0x10), JsonProperty("신용구분")]
    public string? CreditStatus
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("대출일")]
    public string? LoanDate
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
    [DataMember, StringLength(0x10), JsonProperty("예수금")]
    public string? Deposit
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
    [DataMember, StringLength(0x10), JsonProperty("만기일")]
    public string? DueDate
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("신용금액")]
    public string? CreditLoanAmount
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("신용이자")]
    public string? CreditLoanInterest
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("당일실현손익_유가")]
    public string? RealizedProfit
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("당일실현손익률_유가")]
    public string? RealizedProfitRatio
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("당일실현손익_신용")]
    public string? CreditRealizedProfit
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("당일실현손익률_신용")]
    public string? CreditRealizedProfitRatio
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("담보대출수량")]
    public string? MortgageLoanQuantity
    {
        get; set;
    }
    [DataMember, StringLength(0x10)]
    public string? ExtraItem
    {
        get; set;
    }
}