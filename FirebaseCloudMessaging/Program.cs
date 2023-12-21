using ShareInvest.Properties;

Console.Title = Resources.ANTALK;

using (var app = WebApplication.CreateBuilder(args).Build())
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
    }
    app.UseHttpLogging()
       .UseStaticFiles()
       .UseRouting();

    app.MapControllers();
    app.MapFallbackToPage("/_Host");

    app.Run();
}