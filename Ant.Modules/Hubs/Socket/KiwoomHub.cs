using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace ShareInvest.Hubs.Socket;

public class KiwoomHub
{
    public HubConnection Hub
    {
        get;
    }
    public KiwoomHub(string url, string? accessToken = null)
    {
        Hub = new HubConnectionBuilder()
            .WithUrl(url, configureHttpConnection =>
            {
                configureHttpConnection.AccessTokenProvider = () => Task.FromResult(accessToken);
            })
            .AddNewtonsoftJsonProtocol(configure =>
            {
                configure.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
            })
            .ConfigureLogging(configureLogging =>
            {
                configureLogging.SetMinimumLevel(LogLevel.Debug);
            })
            .WithAutomaticReconnect(new[]
            {
                TimeSpan.Zero,
                TimeSpan.FromSeconds(3),
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(7),
                TimeSpan.FromSeconds(9)
            })
            .Build();
    }
}