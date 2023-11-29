using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Entities.Google.Geolocation;

using System.Net;

namespace ShareInvest.Utilities.Google;

public class Geolocation : RestClient
{
    public async Task<GeoResponse> ExecutePostAsync(GeoRequest obj, string? key = null)
    {
        var request = new RestRequest($"geolocation/v1/geolocate?key={key ?? this.key}", Method.Post);

        var response = await ExecuteAsync(request.AddJsonBody(obj), cts.Token);

        if (HttpStatusCode.OK != response.StatusCode || string.IsNullOrEmpty(response.Content))
        {
            return new GeoResponse
            {
                Error = new GeoError
                {
                    Code = (int)response.StatusCode,
                    Message = response.Content ?? string.Empty,
                    Errors = new GeoErrors[] { new() { Message = response.ErrorMessage ?? string.Empty, Domain = response.Server ?? string.Empty, } }
                }
            };
        }
        return JsonConvert.DeserializeObject<GeoResponse>(response.Content);
    }
    public Geolocation() : base("https://www.googleapis.com")
    {
        key = string.Empty;
    }
    public Geolocation(string key) : base("https://www.googleapis.com")
    {
        this.key = key;
    }
    readonly string key;
    readonly CancellationTokenSource cts = new();
}