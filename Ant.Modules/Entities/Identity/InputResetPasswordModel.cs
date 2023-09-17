﻿using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities.Identity;

public class InputResetPasswordModel
{
    [Required, EmailAddress]
    public string? Email
    {
        get; set;
    }
    [Required, DataType(DataType.Password),
     StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    public string? Password
    {
        get; set;
    }
    [DataType(DataType.Password), Display(Name = "Confirm password"),
     Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string? ConfirmPassword
    {
        get; set;
    }
    public string? Code
    {
        get; set;
    }
}