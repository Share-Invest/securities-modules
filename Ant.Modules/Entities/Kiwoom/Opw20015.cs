using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Kiwoom;

/// <summary>옵션매도주문증거금</summary>
public class Opw20015 : MultiOpw20015
{
    [StringLength(8), Key]
    public string? Date
    {
        get; set;
    }

    [StringLength(8), Key]
    public string? Classification
    {
        get; set;
    }
}