# The [![NuGet](https://img.shields.io/badge/NuGet-004880?style=plastic&logoColor=white&logo=nuget)](https://nuget.org) package is [![NuGet](https://img.shields.io/nuget/v/ShareInvest.OpenAPI.Core?label=ShareInvest.OpenAPI.Core&style=plastic&logo=nuget&color=004880)](https://www.nuget.org/packages/ShareInvest.OpenAPI.Core).
### · How to initailize in WPF [![Windows](https://img.shields.io/badge/Windows-0078D6?style=plastic&logoColor=white&logo=windows)](https://www.microsoft.com/en-us/windows) [![Platform](https://img.shields.io/badge/dotnet-512BD4?style=plastic&logoColor=white&logo=.NET)](https://dotnet.microsoft.com/) [![Language](https://img.shields.io/badge/CSharp-239120?style=plastic&logoColor=white&logo=C%20Sharp)](https://learn.microsoft.com/en-us/dotnet/csharp/) [![IDE](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://visualstudio.microsoft.com)
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
### · How to use CommRqData in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=.NET&style=plastic&logo=windows&color=512BD4)](https://versionsof.net)
```C#
public partial class Test : Window
{
    public Test()
    {
        ...
        
        axAPI.OnReceiveTrData += (object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e) =>
        {
            var tr = axAPI.GetTrData(e.sTrCode);

            var data = new Dictionary<string, string>();

            for (int i = 0; i < tr.SingleData?.Length; i++)
            {
                data[tr.SingleData[i]] =
                
                    axAPI.GetCommData(e.sTrCode, e.sRQName, 0, tr.SingleData[i]).Trim();
            }
            for (int cnt = 0; cnt < axAPI.GetRepeatCnt(e.sTrCode, e.sRecordName); cnt++)
            {
                for (int i = 0; i < tr.MultiData?.Length; i++)
                {
                    data[tr.MultiData[i]] =
                    
                        axAPI.GetCommData(e.sTrCode, e.sRQName, cnt, tr.MultiData[i]).Trim();
                }
            }
        };
    }
    void CommRqData()
    {
        /// <param name="sTrCode">주식기본정보요청</param>
        var tr = axAPI.GetTrData("opt10001");

        for (int i = 0; i < tr.Input?.Length; i++)
        {
            /// <param name="sValue">삼성전자</param>
            axAPI.SetInputValue(tr.Input[i], "005930");
        }
        /// <param name="sScreenNo">화면번호</param>
        int errCode = axAPI.CommRqData(tr.Name, tr.Code, 0, "8080");

        string errMsg = Market.Error[errCode];
    }
    readonly ShareInvest.AxKHCoreAPI axAPI;
}
```
### ☞ [![OPENAPI CORE](https://github.com/Share-Invest/securities-modules/actions/workflows/open-api-core.yml/badge.svg?branch=NET7&event=push)](https://github.com/Share-Invest/securities-modules/actions/workflows/open-api-core.yml) is also available in AnyCPU.
