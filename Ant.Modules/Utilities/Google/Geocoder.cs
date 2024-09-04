using Geocoding;
using Geocoding.Google;

namespace ShareInvest.Utilities.Google;

public class Geocoder(string apiKey) : GoogleGeocoder(apiKey), IGeocoder
{

}