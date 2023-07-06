using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RestSharp;

using System.Diagnostics;
using System.Net;
using System.Text;

namespace ShareInvest.Infrastructure;

public class TacticianClient : RestClient
{
    public async Task<ChartInventory?> GetChartInventoryAsync(string route, JToken token)
    {
        var resource = Parameter.TransformQuery(token, new StringBuilder(route));

        var res = await ExecuteAsync(new RestRequest(resource), cts.Token);

        WriteLine(resource, res.StatusCode);

        if (string.IsNullOrEmpty(res.Content))
        {
            return null;
        }
        return JsonConvert.DeserializeObject<ChartInventory>(res.Content);
    }
    public async Task<string[]> GetCodeInventoryAsync(string route)
    {
        var resource = Parameter.TransformOutbound(route);

        var res = await ExecuteAsync(new RestRequest(resource), cts.Token);

        WriteLine(resource, res.StatusCode);

        if (string.IsNullOrEmpty(res.Content))
        {
            return Array.Empty<string>();
        }
        return JsonConvert.DeserializeObject<string[]>(res.Content) ?? Array.Empty<string>();
    }
    public TacticianClient(string url) : base(url)
    {
        cts = new CancellationTokenSource();
    }
    static void WriteLine(string resource, HttpStatusCode statusCode)
    {
        if (HttpStatusCode.OK != statusCode)
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
    }
    readonly CancellationTokenSource cts;
}