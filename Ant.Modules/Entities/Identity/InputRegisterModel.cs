using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputRegisterModel
{
    [Display(Name = "Email"), Required, EmailAddress]
    public string? Email
    {
        get; set;
    }
    [DataType(DataType.Password), Display(Name = "Password"),
     StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6), Required]
    public string? Password
    {
        get; set;
    }
    [Display(Name = "Confirm password"), DataType(DataType.Password),
     Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword
    {
        get; set;
    }
}