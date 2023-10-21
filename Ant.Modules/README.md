### · Implemented as [![Platform](https://img.shields.io/nuget/v/Microsoft.NETCore.Platforms?label=CSharp&style=plastic&logo=.NET&color=512BD4)](https://versionsof.net) using [![IDE](https://img.shields.io/badge/Visual%20Studio-2022-5C2D91?style=plastic&logoColor=white&logo=visualstudio)](https://learn.microsoft.com/en-us/visualstudio/releases/2022).
<a href=http://share.enterprises><img src=https://user-images.githubusercontent.com/48705422/277124891-9f3f6e9d-70e4-4deb-90a3-5cfd5147123a.png></a>
### · **Click** on the image
you will **visit the site** implemented through [![Language](https://img.shields.io/badge/Blazor-512BD4?style=plastic&logoColor=white&logo=blazor)](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-7.0&WT.mc_id=dotnet-35129-website) [![Language](https://img.shields.io/badge/JavaScript-F7DF1E?style=plastic&logoColor=white&logo=javascript)](https://developer.mozilla.org/en-US/docs/Web/JavaScript) alongside [![Language](https://img.shields.io/badge/GoogleMaps-4285F4?style=plastic&logoColor=white&logo=googlemaps)](https://developers.google.com/maps/documentation/javascript/reference/webgl).   
<br>
### · `Web Application Server` implemented as [![Platform](https://img.shields.io/badge/dotnet-512BD4?style=plastic&logoColor=white&logo=.NET)](https://dotnet.microsoft.com/) [![Language](https://img.shields.io/badge/CSharp-239120?style=plastic&logoColor=white&logo=C%20Sharp)](https://learn.microsoft.com/en-us/dotnet/csharp/) alongside [![Language](https://img.shields.io/badge/MySQL-4479A1?style=plastic&logoColor=white&logo=mysql)](https://docs.oracle.com/en-us/iaas/mysql-database/doc/getting-started.html).
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
### · `Proxy Server` implemented as [![Language](https://img.shields.io/badge/NGINX-009639?style=plastic&logoColor=white&logo=nginx)](https://docs.nginx.com).
