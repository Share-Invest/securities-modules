using ShareInvest;

using (var api = new OpenDart("YOUR_OPENDART_API_KEY"))
{
    var res = await api.GetCorpCodeAsync();

    Console.WriteLine(new
    {
        message = res.Item2,
        StatusCode = res.Item1
    });
}