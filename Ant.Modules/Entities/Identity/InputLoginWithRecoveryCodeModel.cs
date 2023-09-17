using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputLoginWithRecoveryCodeModel
{
    [Required, DataType(DataType.Text), Display(Name = "Recovery Code")]
    public string? RecoveryCode
    {
        get; set;
    }
}