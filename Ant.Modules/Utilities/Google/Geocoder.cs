using Geocoding;
using Geocoding.Google;

namespace ShareInvest.Utilities.Google;

public class Geocoder : GoogleGeocoder, IGeocoder
{
    public Geocoder(string apiKey) : base(apiKey)
    {

    }
}