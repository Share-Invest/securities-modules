using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputLoginWith2faModel
{
    [Required, DataType(DataType.Text), Display(Name = "Authenticator code"),
     StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string? TwoFactorCode
    {
        get; set;
    }
    [Display(Name = "Remember this machine")]
    public bool RememberMachine
    {
        get; set;
    }
}