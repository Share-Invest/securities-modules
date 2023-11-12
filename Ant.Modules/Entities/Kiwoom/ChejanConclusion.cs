using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Kiwoom;

public class ChejanConclusion : Chejan
{
    [DataMember, StringLength(0x10), JsonProperty("주문번호"), Key]
    public string? OrderNumber
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("체결번호")]
    public string? ContractNumber
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("관리자사번")]
    public string? AdminNumber
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("주문업무분류")]
    public string? OrderClassification
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("주문상태")]
    public string? OrderState
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("주문수량")]
    public string? OrderQuantity
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("주문가격")]
    public string? OrderPrice
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("미체결수량")]
    public string? UntradedQuantity
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("체결누계금액")]
    public string? CumulativeContractAmount
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("원주문번호")]
    public string? OriginalOrderNumber
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("주문구분")]
    public string? OrderStatus
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("매매구분")]
    public string? TradedClassification
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("매도수구분")]
    public string? SellAndBuyClassification
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("주문_체결시간")]
    public string? OrderFulfillmentTime
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("체결가")]
    public string? ExecutionPrice
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("체결량")]
    public string? ExecutionQuantity
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
    [DataMember, StringLength(0x10), JsonProperty("단위체결가")]
    public string? UnitContractPrice
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("단위체결량")]
    public string? UnitContractAmount
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("당일매매수수료")]
    public string? TradingFee
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("당일매매세금")]
    public string? Tax
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("거부사유")]
    public string? ReasonForRefusal
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("화면번호")]
    public string? ScreenNumber
    {
        get; set;
    }
    [DataMember, StringLength(0x10), JsonProperty("터미널번호")]
    public string? TerminalNumber
    {
        get; set;
    }
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
}