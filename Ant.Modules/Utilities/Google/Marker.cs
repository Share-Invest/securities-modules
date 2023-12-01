using ShareInvest.Entities.Google;
using ShareInvest.Entities.Google.Maps;
using ShareInvest.Services.Google;

using System.Drawing;

namespace ShareInvest.Utilities.Google;

public static class Marker
{
    public static string MakeSignAccording(string? compareToPreviousSign)
    {
        return compareToPreviousSign switch
        {
            "2" => "<span class=\"oi oi-caret-top oi-padding\" ></span>",
            "5" => "<span class=\"oi oi-caret-bottom oi-padding\" ></span>",
            "1" => "<span class=\"oi oi-arrow-thick-top oi-padding\" ></span>",
            "4" => "<span class=\"oi oi-arrow-thick-bottom oi-padding\" ></span>",
            _ => string.Empty
        };
    }
    public static object MakeClientMarker(CoordinateUser user)
    {
        return new
        {
            position = new
            {
                lat = user.Coordinate.Lat,
                lng = user.Coordinate.Lng
            },
            before = new Func<string>(() =>
            {
                if (user.OpenMessage != null)
                {
                    return user.OpenMessage.Title;
                }
                return string.Empty;
            })(),
            after = new Func<string>(() =>
            {
                if (user.OpenMessage != null)
                {
                    return $"[{user.OpenMessage.Screen}] {user.OpenMessage.Code}";
                }
                return string.Empty;
            })(),
            html = new Func<string>(() =>
            {
                if (user.OpenMessage != null)
                {
                    return new DateTime(Cache.Epoch + user.OpenMessage.Lookup).ToString("g");
                }
                return string.Empty;
            })(),
            code = user.SerialKey,
            imageUrl = user.Image,
            name = user.Name,
        };
    }
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
            _ => Color.GhostWhite
        };
        return new
        {
            position = new
            {
                lat = stock.Latitude,
                lng = stock.Longitude
            },
            background,
            borderColor,
            name = stock.Name,
            code = stock.Code,
            glyphColor = Color.WhiteSmoke,
            before = stock.Rate.ToString("P2"),
            after = stock.Current.ToString("N0"),
            html = string.Concat(MakeSignAccording(stock.CompareToPreviousSign), stock.CompareToPreviousDay.ToString("N0"))
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