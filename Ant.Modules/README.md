# <a href=https://github.com/Share-Invest/securities-modules><img height=32 src=https://user-images.githubusercontent.com/48705422/244874765-84542955-0cb8-4961-a546-388c7f391e61.png></a> **동학개미운동** supports [![OS](https://img.shields.io/badge/Windows-0078D6?style=plastic&logoColor=white&logo=windows)](https://www.microsoft.com/en-us/windows) [![OS](https://img.shields.io/badge/Linux-FCC624?style=plastic&logoColor=white&logo=linux)](https://ubuntu.com) [![OS](https://img.shields.io/badge/ios-000000?style=flat&logoColor=white)](https://developer.apple.com) [![OS](https://img.shields.io/badge/android-3DDC84?style=plastic&logo=android&logoColor=white)](https://developer.android.com).
### · Implemented as [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) using [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022).
<a href=http://share.enterprises><img width=512 src=https://user-images.githubusercontent.com/48705422/276548596-77710a02-1174-4385-b291-a32b488d9aed.png></a>
### · **Click** on the image
you will **visit the site** implemented through [![Language](https://img.shields.io/badge/Blazor-512BD4?style=plastic&logoColor=white&logo=blazor)](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-7.0&WT.mc_id=dotnet-35129-website) [![Language](https://img.shields.io/badge/JavaScript-F7DF1E?style=plastic&logoColor=white&logo=javascript)](https://developer.mozilla.org/en-US/docs/Web/JavaScript) alongside [![Language](https://img.shields.io/badge/GoogleMaps-4285F4?style=plastic&logoColor=white&logo=googlemaps)](https://developers.google.com/maps/documentation/javascript/reference/webgl).   
<br>
### · WAS implemented as [![Platform](https://img.shields.io/badge/dotnet-512BD4?style=plastic&logoColor=white&logo=.NET)](https://dotnet.microsoft.com/) [![Language](https://img.shields.io/badge/CSharp-239120?style=plastic&logoColor=white&logo=C%20Sharp)](https://learn.microsoft.com/en-us/dotnet/csharp/) alongside [![Language](https://img.shields.io/badge/MySQL-4479A1?style=plastic&logoColor=white&logo=mysql)](https://docs.oracle.com/en-us/iaas/mysql-database/doc/getting-started.html).
```csharp
using (var app = WebApplication.CreateBuilder(args).Configure().Build())
{
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Error");
    }
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    })
        .UseHttpLogging()
        .UseResponseCompression()
        .UseStaticFiles()
        .UseRouting()
        .UseAuthentication()
        .UseAuthorization();

    app.MapControllers();
    app.MapBlazorHub(configureOptions =>
    {

    });
    app.MapFallbackToPage("/_Host");
    app.ConfigureHubs().Run();
}
```
### · Proxy Server implemented as [![Language](https://img.shields.io/badge/NGINX-009639?style=plastic&logoColor=white&logo=nginx)](https://docs.nginx.com).
