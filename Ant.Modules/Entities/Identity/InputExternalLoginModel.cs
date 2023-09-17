using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputExternalLoginModel
{
    [Required, EmailAddress]
    public string? Email
    {
        get; set;
    }
}