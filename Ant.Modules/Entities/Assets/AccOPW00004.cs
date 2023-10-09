﻿using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ShareInvest.Entities.Assets;

public class AccOPW00004 : AccountBook
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
    [DataMember, JsonProperty("계좌명"), StringLength(0x10)]
    public string? Name
    {
        get; set;
    }
    [DataMember, JsonProperty("지점명"), StringLength(0x10)]
    public string? Branch
    {
        get; set;
    }
    [DataMember, JsonProperty("예수금"), StringLength(0x10)]
    public string? Deposit
    {
        get; set;
    }
    [DataMember, JsonProperty("D+2추정예수금"), StringLength(0x10)]
    public string? PresumeDeposit
    {
        get; set;
    }
    [DataMember, JsonProperty("유가잔고평가액"), StringLength(0x10)]
    public string? Balance
    {
        get; set;
    }
    [DataMember, JsonProperty("예탁자산평가액"), StringLength(0x10)]
    public string? Asset
    {
        get; set;
    }
    [DataMember, JsonProperty("총매입금액"), StringLength(0x10)]
    public string? TotalPurchaseAmount
    {
        get; set;
    }
    [DataMember, JsonProperty("추정예탁자산"), StringLength(0x10)]
    public string? PresumeAsset
    {
        get; set;
    }
    [DataMember, JsonProperty("매도담보대출금"), StringLength(0x10)]
    public string? MortgageLoan
    {
        get; set;
    }
    [DataMember, JsonProperty("당일투자원금"), StringLength(0x10)]
    public string? SameDayInvestment
    {
        get; set;
    }
    [DataMember, JsonProperty("당월투자원금"), StringLength(0x10)]
    public string? CurrentMonthInvestment
    {
        get; set;
    }
    [DataMember, JsonProperty("누적투자원금"), StringLength(0x10)]
    public string? AccumulatedInvestment
    {
        get; set;
    }
    [DataMember, JsonProperty("당일투자손익"), StringLength(0x10)]
    public string? SameDayProfitAndLoss
    {
        get; set;
    }
    [DataMember, JsonProperty("당월투자손익"), StringLength(0x10)]
    public string? CurrentMonthProfitAndLoss
    {
        get; set;
    }
    [DataMember, JsonProperty("누적투자손익"), StringLength(0x10)]
    public string? AccumulatedProfitAndLoss
    {
        get; set;
    }
    [DataMember, JsonProperty("당일손익율"), StringLength(0x10)]
    public string? ProfitAndLossPercentageForTheDay
    {
        get; set;
    }
    [DataMember, JsonProperty("당월손익율"), StringLength(0x10)]
    public string? ProfitAndLossPercentageForTheCurrentMonth
    {
        get; set;
    }
    [DataMember, JsonProperty("누적손익율"), StringLength(0x10)]
    public string? CumulativeProfitPercentage
    {
        get; set;
    }
    [DataMember, JsonProperty("출력건수"), StringLength(4)]
    public string? NumberOfPrints
    {
        get; set;
    }
}