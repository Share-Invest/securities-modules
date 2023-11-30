using NetTopologySuite.Geometries;

using System.ComponentModel.DataAnnotations;

namespace ShareInvest.Entities;

public class Position
{
    [StringLength(0x40), Key]
    public string? SerialKey
    {
        get; set;
    }
    [StringLength(0x40)]
    public string? UserId
    {
        get; set;
    }
    [StringLength(0x20), Required]
    public string? MacAddress
    {
        get; set;
    }
    public double Longitude
    {
        get; set;
    }
    public double Latitude
    {
        get; set;
    }
    public Point? Geometry
    {
        get; set;
    }
}