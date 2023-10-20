using ShareInvest.Entities.Google.Maps;
using ShareInvest.Services.Google;

using System.Drawing;

namespace ShareInvest.Utilities.Google;

public static class Marker
{
    public static object MakeStockMarker(MapStock stock)
    {
        var background = stock.CompareToPreviousSign switch
        {
            "2" or "1" => Color.Red,
            "5" or "4" => Color.Blue,
            _ => Color.Black
        };
        var borderColor = stock.CompareToPreviousSign switch
        {
            "2" or "1" => Color.Maroon,
            "5" or "4" => Color.Navy,
            _ => Color.Black
        };
        return new
        {
            background,
            borderColor,
            position = new
            {
                lat = stock.Latitude,
                lng = stock.Longitude
            },
            glyphColor = Color.WhiteSmoke,
            name = stock.Name,
            code = stock.Code
        };
    }
    public static string GetMarkerImageUrl(string? url, string color)
    {
        return Path.Combine(url ?? "http://share.enterprises", "images", "pins", $"pin_{color}.png");
    }
    public static bool HasCenterChanged(MapEventName eventName, MapStatus currentMapStatus, MapStatus previousMapStatus)
    {
        if (MapEventName.heading_changed == eventName || MapEventName.tilt_changed == eventName)
        {
            return true;
        }
        return currentMapStatus.Center.Lng != previousMapStatus.Center.Lng || currentMapStatus.Center.Lat != previousMapStatus.Center.Lat;
    }
}