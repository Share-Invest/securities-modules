using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RestSharp;

using ShareInvest.Entities;

using System.Net;

namespace ShareInvest;

public class OpenDart : RestClient
{
    public async Task<DartCompany?> GetCompanyAsync(string corpCode)
    {
        var resource = Resource.Get("api/company.json", token: JToken.FromObject(new
        {
            crtfc_key = apiKey,
            corp_code = corpCode
        }));
        var res = await ExecuteAsync(new RestRequest(resource), cancellationToken: cts.Token);

        if (HttpStatusCode.OK != res.StatusCode)
        {
            return null;
        }
        return string.IsNullOrEmpty(res.Content) ? null : JsonConvert.DeserializeObject<DartCompany>(res.Content);
    }
    public async IAsyncEnumerable<DartCode> GetEnumerableCorpCodeAsync()
    {
        var resource = Resource.Get("api/corpCode.xml", token: JToken.FromObject(new
        {
            crtfc_key = apiKey
        }));
        var res = await ExecuteAsync(new RestRequest(resource), cancellationToken: cts.Token);

        if (HttpStatusCode.OK == res.StatusCode && res.RawBytes != null)
        {
            foreach (var corpCode in Resource.GetEnumerator(res.RawBytes))
            {
                yield return corpCode;
            }
        }
    }
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