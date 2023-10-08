### · How to use in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
using (var api = new OpenDart("YOUR_OPEN_DART_API_KEY"))
{
    /// Run Delay & set the delay time in milliseconds.
    Delay.Instance.Run();
    Delay.Instance.Milliseconds = 0x800;

    await foreach (var dart in api.GetEnumerableCorpCodeAsync())
    {
        Task task = new () => { ... };

        /// Create and instill the mission.
        Delay.Instance.RequestTheMission(task);
    }
}
```
### [· For detailed examples, follow the link.](https://github.com/Share-Invest/securities-modules/blob/NET7/Test.OpenDart/Program.cs)
