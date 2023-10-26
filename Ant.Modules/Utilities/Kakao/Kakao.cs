using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Entities.Kakao.Geo;

using System.Net;

namespace ShareInvest.Utilities;

public class Kakao : RestClient
{
    public async Task<object> GetAddressAsync(string address)
    {
        try
        {
            var response = await ExecuteAsync(new RestRequest(string.Concat(searchAddress, address)), cts.Token);

            if (HttpStatusCode.OK == response.StatusCode && !string.IsNullOrEmpty(response.Content))
            {
                return JsonConvert.DeserializeObject<LocalAddress>(response.Content).Document;
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return Array.Empty<Response>();
    }
    public Kakao(string accessToken) : base("https://dapi.kakao.com", configureDefaultHeaders: headers =>
    {
        headers.Add(KnownHeaders.Authorization, $"KakaoAK {accessToken}");
    })
    {
        cts = new CancellationTokenSource();
    }
    readonly CancellationTokenSource cts;

    const string searchAddress = "v2/local/search/address?query=";
}