using ShareInvest;

using System.Net;

using (var api = new OpenDart("YOUR_OPEN_DART_API_KEY"))
{
    var res = await api.GetCorpCodeAsync();

    Console.WriteLine(new
    {
        message = res.Item2,
        StatusCode = res.Item1
    });
    if (HttpStatusCode.OK == res.Item1)
    {

    }
}