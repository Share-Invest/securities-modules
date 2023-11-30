using ShareInvest.Entities.Google.Maps;

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
    public bool IsRendering
    {
        get; set;
    }
}