﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareInvest.Entities;

public class Securities
{
    [StringLength(0x10), Key]
    public string? AccNo
    {
        get; set;
    }

    [StringLength(0x40), Key]
    public string? SerialKey
    {
        get; set;
    }

    [StringLength(0x20)]
    public string? UserName
    {
        get; set;
    }

    [StringLength(0x40), Key]
    public string? UserId
    {
        get; set;
    }

    [StringLength(0x20), Required]
    public string? SecuritiesId
    {
        get; set;
    }

    [StringLength(0x20), NotMapped]
    public string? MacAddress
    {
        get; set;
    }
}