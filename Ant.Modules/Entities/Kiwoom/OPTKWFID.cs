using ShareInvest.OpenAPI.Entity;

using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Kiwoom;

public class OPTKWFID : MultiOPTKWFID
{
    [StringLength(0x40)]
    public string? State
    {
        get; set;
    }
    [StringLength(0x80)]
    public string? ConstructionSupervision
    {
        get; set;
    }
    [StringLength(0x10)]
    public string? InvestmentCaution
    {
        get; set;
    }
    [StringLength(8)]
    public string? ListingDate
    {
        get; set;
    }
}