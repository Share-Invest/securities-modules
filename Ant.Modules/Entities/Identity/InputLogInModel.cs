using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputLogInModel : InputModel
{
    [Required, DataType(DataType.Password)]
    public string? Password
    {
        get; set;
    }
    [Display(Name = "Remember me?")]
    public bool RememberMe
    {
        get; set;
    }
}