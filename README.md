# Build using  [![NuGet](https://img.shields.io/badge/NuGet-004880?style=plastic&logoColor=white&logo=nuget)](https://www.nuget.org/packages/ShareInvest.OpenAPI.Core) [![Build](https://img.shields.io/badge/GitHub%20Actions-2088FF?style=plastic&logoColor=white&logo=githubactions)](https://docs.github.com)
### · Desktop package is [![NuGet](https://img.shields.io/nuget/v/ShareInvest.OpenAPI.Core?label=NuGet&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.OpenAPI.Core) [![.NET PACKAGE](https://github.com/Share-Invest/Algorithmic-Trading-Package/actions/workflows/package-desktop.yml/badge.svg?event=push)](https://github.com/Share-Invest/Algorithmic-Trading-Package/actions/workflows/package-desktop.yml).
## How to initailize in WPF

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
### IDE using [![IDE](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://visualstudio.microsoft.com) and [![IDE](https://img.shields.io/badge/VS%20Code-007ACC?style=plastic&logoColor=white&logo=visualstudiocode)](https://code.visualstudio.com)
