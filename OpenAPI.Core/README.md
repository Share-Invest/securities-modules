## · How to initailize in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
public partial class Test : Window
{
    public Test()
    {
        nint handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

        InitializeComponent();

        axAPI = new ShareInvest.AxKHCoreAPI(handle, ShareInvest.Process.x86);
    }
    readonly ShareInvest.AxKHCoreAPI axAPI;
}
```
### [![NuGet](https://img.shields.io/nuget/v/ShareInvest.OpenAPI.Core?label=ShareInvest.OpenAPI.Core&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.OpenAPI.Core) make KHOpenAPI available to AnyCPU.
