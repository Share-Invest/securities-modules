using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using ShareInvest.Observers;
using ShareInvest.Properties;
using ShareInvest.Services;

using Skender.Stock.Indicators;

namespace ShareInvest.Hubs.Socket;

public class ChartHub : IEventHandler<MsgEventArgs>
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
    public ChartHub(Uri uri, string? userName = null)
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

        _ = Hub.On<Quote, bool>(nameof(IHubs.TransmitFuturesQuoteAsync), (quote, moreThanBefore) => Send?.Invoke(this, new HubQuoteArgs(quote, moreThanBefore)));

        _ = Hub.On<object>(nameof(IHubs.TransmitMarkerAsync), marker => Send?.Invoke(this, new HubMarkerArgs(marker)));
    }
    public HubConnection Hub
    {
        get;
    }
    public event EventHandler<MsgEventArgs>? Send;
}