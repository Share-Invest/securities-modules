using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using ShareInvest.Observers;
using ShareInvest.Properties;

namespace ShareInvest.Hubs.Socket;

public class KiwoomHub
{
    public async Task AddToGroupAsync(string groupName)
    {
        if (HubConnectionState.Connected == Hub.State)
        {
            await Hub.SendAsync(nameof(AddToGroupAsync), groupName);
        }
    }
    public async Task RemoveFromGroupAsync(string groupName)
    {
        if (HubConnectionState.Connected == Hub.State)
        {
            await Hub.SendAsync(nameof(RemoveFromGroupAsync), groupName);
        }
    }
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

        _ = Hub.On<string>(nameof(IHubs.InstructToRenewAssetStatus), accNo => Send?.Invoke(this, new AssetsEventArgs(accNo)));
    }
    public event EventHandler<MsgEventArgs>? Send;
}