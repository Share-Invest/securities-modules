using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputDeletePersonalDataModel
{
    [Required, DataType(DataType.Password)]
    public string? Password
    {
        get; set;
    }
}