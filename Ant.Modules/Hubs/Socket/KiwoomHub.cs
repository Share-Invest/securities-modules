using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using ShareInvest.Properties;

namespace ShareInvest.Hubs.Socket;

public class KiwoomHub
{
    public HubConnection Hub
    {
        get;
    }
    public KiwoomHub(string url, string? accessToken = null, string? serialKey = null)
    {
        Hub = new HubConnectionBuilder()
            .WithUrl(url, configureHttpConnection =>
            {
                if (string.IsNullOrEmpty(serialKey) is false)
                {
                    _ = configureHttpConnection.Headers.TryAdd(Resources.KEY, serialKey);
                }
                configureHttpConnection.AccessTokenProvider = () => Task.FromResult(accessToken);
            })
            .AddNewtonsoftJsonProtocol(configure =>
            {
                configure.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
            })
            .ConfigureLogging(configureLogging =>
            {
                configureLogging.SetMinimumLevel(LogLevel.Trace);
            })
            .Build();
    }
}