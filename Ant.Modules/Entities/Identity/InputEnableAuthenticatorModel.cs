using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputEnableAuthenticatorModel
{
    [Required, DataType(DataType.Text), Display(Name = "Verification Code"),
     StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string? Code
    {
        get; set;
    }
}