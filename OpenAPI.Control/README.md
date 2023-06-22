## · How to initailize in [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022)
```C#
<Window x:Class="ShareInvest.CoreWindow"

        ...
        
        xmlns:local="clr-namespace:ShareInvest;assembly=ShareInvest.OpenAPI.Control"
        mc:Ignorable="d"
        d:DataContext="{d:DesignInstance IsDesignTimeCreatable=True}">

    <local:AxKHCoreAPIControl />

</Window>
```
### or
```C#
public partial class Test : Window
{
    public Test()
    {
        Content = new ShareInvest.AxKHCoreAPIControl();

        InitializeComponent();
    }
}
```
### library for controlling information received from Kiwoom OpenAPI.
