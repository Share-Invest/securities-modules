using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities;

public class Kiwoom : Securities
{
    [NotMapped]
    public string[]? Accounts
    {
        get; set;
    }
}