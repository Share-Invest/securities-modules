# The [![NuGet](https://img.shields.io/badge/NuGet-004880?style=plastic&logoColor=white&logo=nuget)](https://www.nuget.org/packages/ShareInvest.OpenAPI.Core) package is [![NuGet](https://img.shields.io/nuget/v/ShareInvest.OpenAPI.Core?label=ShareInvest.OpenAPI.Core&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.OpenAPI.Core).
## How to initailize in WPF [![Windows](https://img.shields.io/badge/Windows-0078D6?style=plastic&logoColor=white&logo=windows)](https://www.microsoft.com/en-us/windows) [![Platform](https://img.shields.io/badge/dotnet-512BD4?style=plastic&logoColor=white&logo=.NET)](https://dotnet.microsoft.com/) [![Language](https://img.shields.io/badge/CSharp-239120?style=plastic&logoColor=white&logo=C%20Sharp)](https://learn.microsoft.com/en-us/dotnet/csharp/) [![IDE](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://visualstudio.microsoft.com)
```C#
public partial class Test : Window
{
    public Test()
    {
        nint handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

        InitializeComponent();

        axAPI = new ShareInvest.AxKHCoreAPI(handle);
    }
    readonly ShareInvest.AxKHCoreAPI axAPI;
}
```
### It is also available in x64 [![OPENAPI CORE](https://github.com/Share-Invest/securities-modules/actions/workflows/open-api-core.yml/badge.svg?branch=NET7&event=push)](https://github.com/Share-Invest/securities-modules/actions/workflows/open-api-core.yml).
