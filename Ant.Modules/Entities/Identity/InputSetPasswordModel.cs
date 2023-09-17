using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputSetPasswordModel
{
    [Required, DataType(DataType.Password), Display(Name = "New password"),
     StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string? NewPassword
    {
        get; set;
    }
    [DataType(DataType.Password), Display(Name = "Confirm new password"),
     Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
    public string? ConfirmPassword
    {
        get; set;
    }
}