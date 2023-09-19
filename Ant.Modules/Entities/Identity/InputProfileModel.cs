using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputProfileModel : InputModel
{
    [Phone, Display(Name = "Phone number")]
    public string? PhoneNumber
    {
        get; set;
    }
}