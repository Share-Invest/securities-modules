using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RestSharp;

using ShareInvest.Entities;

using System.Net;

namespace ShareInvest;

public class OpenDart : RestClient
{
    /// <summary>Disclosure Inquiry</summary>
    /// <param name="corpCode">Corp Code</param>
    /// <param name="inquiryDate">yyyyMMdd</param>
    /// <param name="pageCount">100 is the maximum</param>
    /// <returns><see cref="DartDisclousure"/></returns>
    public async Task<DartDisclousure[]?> GetDisclousureInventoryAsync(string corpCode, string? inquiryDate = null, int pageCount = 100)
    {
        var resource = Resource.Get("api/list.json", token: JToken.FromObject(new
        {
            crtfc_key = apiKey,
            corp_code = corpCode,
            page_count = pageCount,
            bgn_de = string.IsNullOrEmpty(inquiryDate) ? DateTime.Now.ToString("yyyyMMdd") : inquiryDate
        }));
        var res = await ExecuteAsync(new RestRequest(resource), cancellationToken: cts.Token);

        if (HttpStatusCode.OK != res.StatusCode || string.IsNullOrEmpty(res.Content))
        {
            return null;
        }
        var disclousure = JsonConvert.DeserializeObject<DartDisclousureInventory>(res.Content);

        var status = Convert.ToInt32(disclousure?.Status);

        if (status == 0)
        {
            return disclousure?.Inventory;
        }
        return Array.Empty<DartDisclousure>();
    }
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