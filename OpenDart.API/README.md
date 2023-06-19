# The [![NuGet](https://img.shields.io/badge/NuGet-004880?style=plastic&logoColor=white&logo=nuget)](https://nuget.org) package is [![NuGet](https://img.shields.io/nuget/v/ShareInvest.OpenDart.API?label=ShareInvest.OpenDart.API&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.OPENDART.API).
### · How to initailize in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
using (var api = new OpenDart("YOUR_OPEN_DART_API_KEY"))
{
    var res = await api.GetCorpCodeAsync();

    Console.WriteLine(new
    {
        message = res.Item2,
        StatusCode = res.Item1
    });
    /// OPEN DART CorpCode가 JsonArray로 반환되면 초기화 성공
}
```
### · How to use GetCorpCode in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
using (var api = new OpenDart("YOUR_OPEN_DART_API_KEY"))
{
    var res = await api.GetCorpCodeAsync();

    var corpCodes = JsonConvert.DeserializeObject<DartCode[]>(res.Item2);

    /// or

    await foreach (DartCode e in api.GetEnumerableCorpCodeAsync())
    {
        ...
    }
}
```
### · How to use GetCompany in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
using (var api = new OpenDart("YOUR_OPEN_DART_API_KEY"))
{
    ...
    
    await foreach (DartCode e in api.GetEnumerableCorpCodeAsync())
    {
        if (string.IsNullOrEmpty(e.CorpCode))
        {
            continue;
        }
        DartCompany? company = await api.GetCompanyAsync(e.CorpCode);

        if (company != null)
        {
            ...
        }
        await Task.Delay(0x50);
    }
}
```
### · How to use GetDisclousureInventory in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
using (var api = new OpenDart("YOUR_OPEN_DART_API_KEY"))
{
    ...
    
    await foreach (DartCode e in api.GetEnumerableCorpCodeAsync())
    {
        ...
        
        DartDisclousure[]? disclousures = await api.GetDisclousureInventoryAsync(e.CorpCode);
    }
}
```
### ☞ library for convenient of [![OPEN DART API](https://github.com/Share-Invest/securities-modules/actions/workflows/open-dart-api.yml/badge.svg?event=push)](https://github.com/Share-Invest/securities-modules/actions/workflows/open-dart-api.yml).
