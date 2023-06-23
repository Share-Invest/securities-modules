## · How to initailize in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
public sealed partial class AxKHCoreAPI : AxKHOpenAPI
{
    public AxKHCoreAPI(nint hWndParent, Process process = Process.x64) : base(hWndParent, process)
    {
        path = Path.Combine(GetAPIModulePath(), Resources.DATA);

        if (Directory.Exists(path))
        {
            TrInventory = InitializeTrInventory();
        }
        else
        {
            throw new DirectoryNotFoundException(Resources.MODULE);
        }
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
}
```
### [![NuGet](https://img.shields.io/nuget/v/ShareInvest.OpenAPI?label=ShareInvest.OpenAPI&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.OpenAPI) make KHOpenAPI available to AnyCPU.
