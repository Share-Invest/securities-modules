using Newtonsoft.Json.Linq;

using RestSharp;

using System.Net;

namespace ShareInvest;

public class OpenDart : RestClient
{
    public async Task<(HttpStatusCode, string?)> GetCorpCodeAsync()
    {
        var resource = Resource.Get("api/corpCode.xml", token: JToken.FromObject(new
        {
            crtfc_key = apiKey
        }));
        var res = await ExecuteAsync(new RestRequest(resource), cancellationToken: cts.Token);

        if (HttpStatusCode.OK != res.StatusCode)
        {
            return (res.StatusCode, null);
        }
        return (res.StatusCode, Resource.ToJson(res.RawBytes, res.Content));
    }
    public OpenDart(string apiKey) : base("https://opendart.fss.or.kr")
    {
        cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(0x400 * 0x40));

        this.apiKey = apiKey;
    }
    readonly string apiKey;
    readonly CancellationTokenSource cts;
}