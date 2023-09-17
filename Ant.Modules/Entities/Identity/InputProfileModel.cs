using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputProfileModel
{
    [Required, EmailAddress]
    public string? Email
    {
        get; set;
    }
    [Phone, Display(Name = "Phone number")]
    public string? PhoneNumber
    {
        get; set;
    }
}