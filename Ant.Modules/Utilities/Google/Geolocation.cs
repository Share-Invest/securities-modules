using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Entities.Google.Geolocation;

using System.Net;

namespace ShareInvest.Utilities.Google;

public class Geolocation : RestClient
{
    public async Task<GeoResponse> ExecutePostAsync(GeoRequest obj, string? resource = null)
    {
        var request = new RestRequest(resource ?? this.resource, Method.Post);

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
    public Geolocation(string baseUrl) : base(baseUrl)
    {
        resource = string.Empty;
    }
    public Geolocation(string baseUrl, string resource) : base(baseUrl)
    {
        this.resource = resource;
    }
    readonly string resource;
    readonly CancellationTokenSource cts = new();
}