using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Assets;

public class AccOPW00005 : AccountBook
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
            lookup = value > Parameter.Epoch ? value - Parameter.Epoch : value;
        }
        get => lookup;
    }
    [StringLength(0x10), DataMember, JsonProperty("예수금")]
    public string? Deposit
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("예수금D+1")]
    public string? PreDeposit
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("예수금D+2")]
    public string? PresumeDeposit
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("출금가능금액")]
    public string? WithDrawableAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("미수확보금")]
    public string? UncollectedSecurity
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("대용금")]
    public string? Loan
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("권리대용금")]
    public string? LoanForRights
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("주문가능현금")]
    public string? OrderableCash
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("현금미수금")]
    public string? CashReceivables
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("신용이자미납금")]
    public string? UnpaidInterestOnCredit
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("기타대여금")]
    public string? OtherLoans
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("미상환융자금")]
    public string? OutstandingLoan
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("증거금현금")]
    public string? CashOnDeposit
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("증거금대용")]
    public string? DepositSubstitute
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("주식매수총액")]
    public string? TotalStockPurchases
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("평가금액합계")]
    public string? EvaluationAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("총손익합계")]
    public string? TotalProfitAndLoss
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("총손익률")]
    public string? GrossProfitAndLossRatio
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("총재매수가능금액")]
    public string? TotalAvailablePurchaseAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("20주문가능금액")]
    public string? OneFifthAvailablePurchaseAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("30주문가능금액")]
    public string? OneThirdAvailablePurchaseAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("40주문가능금액")]
    public string? TwoFifthsAvailablePurchaseAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("50주문가능금액")]
    public string? HalfAvailablePurchaseAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("60주문가능금액")]
    public string? TwoThirdsAvailablePurchaseAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("100주문가능금액")]
    public string? FullAvailablePurchaseAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("신용융자합계")]
    public string? TotalCreditLoans
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("신용융자대주합계")]
    public string? CreditLoan
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("신용담보비율")]
    public string? CreditSecurityRatio
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("예탁담보대출금액")]
    public string? DepositedMortgageAmount
    {
        get; set;
    }
    [StringLength(0x10), DataMember, JsonProperty("매도담보대출금액")]
    public string? MortgageSoldAmount
    {
        get; set;
    }
    [StringLength(0x4), DataMember, JsonProperty("조회건수")]
    public string? NumberOfViews
    {
        get; set;
    }
}