using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputForgotPasswordModel
{
    [Required, EmailAddress]
    public string? Email
    {
        get; set;
    }
}