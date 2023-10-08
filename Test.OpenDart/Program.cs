using Newtonsoft.Json;

using ShareInvest;
using ShareInvest.Entities;

const string KEY = "YOUR_OPEN_DART_API_KEY";

using (var api = new OpenDart(KEY))
{
    var res = await api.GetCorpCodeAsync();

    Console.WriteLine(new
    {
        message = res.Item2,
        StatusCode = res.Item1
    });
    Delay.Instance.Run();
    Delay.Instance.Milliseconds = 0x800;

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
        Delay.Instance.RequestTheMission(new Task(async () =>
        {
            var company = await api.GetCompanyAsync(dart.CorpCode);

            if (company != null)
            {
                var json = JsonConvert.SerializeObject(company, Formatting.Indented);

                Console.WriteLine(json);
            }
            if (await api.GetDisclousureInventoryAsync(dart.CorpCode) is DartDisclousure[] disclousures)
            {
                foreach (var disclousure in disclousures)
                {
                    var json = JsonConvert.SerializeObject(disclousure, Formatting.Indented);

                    Console.WriteLine(json);
                }
            }
        }));
    }
    Console.ReadLine();
}