using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputModel
{
    [Required, EmailAddress]
    public string? Email
    {
        get; set;
    }
}