using Newtonsoft.Json;

using RestSharp;

using System.Diagnostics;
using System.Net;

namespace ShareInvest.Infrastructure;

public class TacticianClient : RestClient
{
    public async Task<string[]> GetCodeInventoryAsync(string route)
    {
        var resource = Parameter.TransformOutbound(route);

        var res = await ExecuteAsync(new RestRequest(resource), cts.Token);

        if (HttpStatusCode.OK != res.StatusCode)
        {
            WriteLine(resource, res.StatusCode);
        }
        if (string.IsNullOrEmpty(res.Content))
        {
            return Array.Empty<string>();
        }
        return JsonConvert.DeserializeObject<string[]>(res.Content) ?? Array.Empty<string>();
    }
    public TacticianClient(string url) : base(url)
    {
        cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(0x400 * 0x40));
    }
    static void WriteLine(string resource, HttpStatusCode statusCode)
    {
        var value = new
        {
            resource,
            statusCode
        };
#if DEBUG
        Debug.WriteLine(value);
#else
        Console.WriteLine(value);
#endif
    }
    readonly CancellationTokenSource cts;
}