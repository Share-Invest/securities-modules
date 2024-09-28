using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Kiwoom;

/// <summary>전업종지수</summary>
public class OPT20003 : MultiOpt20003
{
    [StringLength(8), Key]
    public string? Date
    {
        get; set;
    }
}