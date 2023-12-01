using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using ShareInvest.Observers;
using ShareInvest.Properties;
using ShareInvest.Services;

namespace ShareInvest.Hubs.Socket;

public class MapHub : IEventHandler<MsgEventArgs>
{
    public async Task AddToGroupAsync(string code)
    {
        if (HubConnectionState.Connected == Hub.State)
        {
            await Hub.SendAsync(nameof(AddToGroupAsync), code);
        }
    }
    public async Task RemoveFromGroupAsync(string code)
    {
        if (HubConnectionState.Connected == Hub.State)
        {
            await Hub.SendAsync(nameof(RemoveFromGroupAsync), code);
        }
    }
    public MapHub(Uri uri, string? userName = null)
    {
        Hub = new HubConnectionBuilder()
            .WithUrl(uri, configureHttpConnection =>
            {
                if (string.IsNullOrEmpty(userName) is false)
                {
                    _ = configureHttpConnection.Headers.TryAdd(Resources.USER, userName);
                }
            })
            .AddNewtonsoftJsonProtocol(configure =>
            {
                configure.PayloadSerializerSettings.TypeNameHandling = TypeNameHandling.Auto;
            })
            .ConfigureLogging(configureLogging =>
            {
                configureLogging.SetMinimumLevel(LogLevel.Trace);
            })
            .WithAutomaticReconnect(new[]
            {
                TimeSpan.Zero,
                TimeSpan.FromSeconds(3),
                TimeSpan.FromSeconds(9),
                TimeSpan.FromSeconds(0x10),
                TimeSpan.FromSeconds(0x20)
            })
            .Build();

        _ = Hub.On<string, string>(nameof(IHubs.TransmitConclusionInformationAsync), (code, data) => Send?.Invoke(this, new HubMsgEventArgs(code, data.Split('\t'))));

        _ = Hub.On<string>(nameof(IHubs.TransmitOpenMessageAsync), json => Send?.Invoke(this, new HubOpenMsgArgs(json)));
    }
    public HubConnection Hub
    {
        get;
    }
    public event EventHandler<MsgEventArgs>? Send;
}