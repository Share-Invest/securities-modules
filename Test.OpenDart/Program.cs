using Newtonsoft.Json;

using ShareInvest;

const string KEY = "YOUR_OPEN_DART_API_KEY";

using (var api = new OpenDart(KEY))
{
    var res = await api.GetCorpCodeAsync();

    Console.WriteLine(new
    {
        message = res.Item2,
        StatusCode = res.Item1
    });
    if (string.IsNullOrEmpty(res.Item2) || res.Item2[0] != '[')
    {
        return;
    }
    await foreach (var dart in api.GetEnumerableCorpCodeAsync())
    {
        if (string.IsNullOrEmpty(dart.CorpCode))
        {
            continue;
        }
        await Task.Delay(0x50);

        var company = await api.GetCompanyAsync(dart.CorpCode);

        if (company != null)
        {
            var json = JsonConvert.SerializeObject(company, Formatting.Indented);

            Console.WriteLine(json);
        }
        await Task.Delay(0x50);

        var arr = await api.GetDisclousureInventoryAsync(dart.CorpCode);

        if (arr == null)
        {
            continue;
        }
        foreach (var disclousure in arr)
        {
            var json = JsonConvert.SerializeObject(disclousure, Formatting.Indented);

            Console.WriteLine(json);
        }
    }
}