## · How to use in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
axAPI.OnReceiveTrData += (_, e) =>
{
  var tr = axAPI.GetTrData(e.sTrCode);
  
  var data = new Dictionary<string, string>();

  for (int i = 0; i < tr.SingleData?.Length; i++)
  {
    data[tr.SingleData[i]] = axAPI.GetCommData(e.sTrCode, e.sRQName, 0, tr.SingleData[i]).Trim();
  }
  for (int cnt = 0; cnt < axAPI.GetRepeatCnt(e.sTrCode, e.sRecordName); cnt++)
  {
    for (int i = 0; i < tr.MultiData?.Length; i++)
    {
      data[tr.MultiData[i]] = axAPI.GetCommData(e.sTrCode, e.sRQName, cnt, tr.MultiData[i]).Trim();
    }
  }
  var json = JsonConvert.SerializeObject(data, Formatting.Indented);

  var trData = JsonConvert.DeserializeObject<OPTKWFID>(json);
};
```
### [![NuGet](https://img.shields.io/nuget/v/ShareInvest.OpenAPI.Entity?label=ShareInvest.OpenAPI.Entity&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.OpenAPI.Entity) helps to easily convert JSON data into entities.
