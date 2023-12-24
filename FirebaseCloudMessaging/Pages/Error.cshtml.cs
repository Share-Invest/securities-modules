﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Diagnostics;

namespace ShareInvest.Pages;

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true), IgnoreAntiforgeryToken]
public class ErrorModel(ILogger<ErrorModel> logger) : PageModel
{
    public string? RequestId
    {
        get; set;
    }
    public bool ShowRequestId
    {
        get => !string.IsNullOrEmpty(RequestId);
    }
    public void OnGet()
    {
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

        logger.LogInformation("{ }", RequestId);
    }
    readonly ILogger<ErrorModel> logger = logger;
}