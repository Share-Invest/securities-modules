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
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(4),
                TimeSpan.FromSeconds(8),
                TimeSpan.FromSeconds(0x10),
                TimeSpan.FromSeconds(0x20)
            })
            .Build();

        Hub.ServerTimeout = TimeSpan.FromSeconds(0x40);
        Hub.HandshakeTimeout = TimeSpan.FromSeconds(0x20);
    }
}