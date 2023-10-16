using ShareInvest.Entities.Google;

using System.Drawing;

namespace ShareInvest.Utilities.Google;

public static class Marker
{
    public static object MakeStockMarker(CoordinateStock stock)
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
}