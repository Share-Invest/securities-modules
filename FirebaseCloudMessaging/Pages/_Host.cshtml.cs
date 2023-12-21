using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShareInvest.Pages;

[ValidateAntiForgeryToken, ResponseCache(Duration = 0x400 * 0x100, Location = ResponseCacheLocation.Client, NoStore = false)]
public class HostModel(ILogger<HostModel> logger) : PageModel
{
    public IActionResult OnGet()
    {
        logger.LogInformation("Host: { }, Path: { }, RemoteIpAddress: { }", HttpContext.Request.Host, HttpContext.Request.Path, HttpContext.Connection.RemoteIpAddress);

        return Redirect("http://share.enterprises");
    }
    readonly ILogger<HostModel> logger = logger;
}