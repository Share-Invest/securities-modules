using ShareInvest.Entities.Google.Maps;
using ShareInvest.Entities.Kiwoom;

namespace ShareInvest.Entities.Google;

public class CoordinateUser
{
    public Coordinate Coordinate
    {
        get; set;
    }
    public string? Image
    {
        get; set;
    }
    public string? SerialKey
    {
        get; set;
    }
    public string? Name
    {
        get; set;
    }
    public string? MacAddress
    {
        get; set;
    }
    public bool IsRendering
    {
        get; set;
    }
    public OpenMessage? OpenMessage
    {
        get; set;
    }
}