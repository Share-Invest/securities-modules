using Microsoft.Extensions.Configuration;

using ShareInvest.Properties;

namespace ShareInvest;

static class Extensions
{
    public static IConfigurationRoot Configuration
    {
        get =>

            new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                      .AddJsonFile(Resources.SETTINGS)
                                      .Build();
    }
}