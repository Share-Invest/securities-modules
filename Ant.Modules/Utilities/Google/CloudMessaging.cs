using FirebaseAdmin.Messaging;

using Google.Apis.Auth.OAuth2;

using Newtonsoft.Json;

using RestSharp;

using ShareInvest.Entities.Google.Firebase;

namespace ShareInvest.Utilities.Google;

public class CloudMessaging : RestClient
{
    public async Task<RestResponse> SendMessageAsync(CloudMessage message)
    {
        var json = JsonConvert.SerializeObject(new
        {
            message = new Message
            {
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Body = message.Notification.Body,
                    Title = message.Notification.Title
                },
                Data = message.Data,
                Topic = message.Topic,
                Token = message.Token,
                Condition = message.Condition
            }
        });
        return await ExecuteAsync(new RestRequest(route, Method.Post).AddJsonBody(json), cts.Token);
    }
    public async Task<string> SendAsync(CloudMessage cloudMessage)
    {
        var message = new Message
        {
            Notification = new FirebaseAdmin.Messaging.Notification
            {
                Body = cloudMessage.Notification.Body,
                Title = cloudMessage.Notification.Title
            },
            Data = cloudMessage.Data,
            Topic = cloudMessage.Topic,
            Token = cloudMessage.Token,
            Condition = cloudMessage.Condition
        };
        return await FirebaseMessaging.DefaultInstance.SendAsync(message, cts.Token);
    }
    public async Task<object> SendMulticastAsync(CloudMulticastMessage messages)
    {
        var multicastMessage = new MulticastMessage
        {
            Notification = new FirebaseAdmin.Messaging.Notification
            {
                Body = messages.Notification.Body,
                Title = messages.Notification.Title
            },
            Data = messages.Data,
            Tokens = messages.Tokens
        };
        return await FirebaseMessaging.DefaultInstance.SendMulticastAsync(multicastMessage, cts.Token);
    }
    public async Task<object> SendAllAsync(IEnumerable<CloudMessage> cloudMessages)
    {
        var messages = cloudMessages.Select(s => new Message
        {
            Notification = new FirebaseAdmin.Messaging.Notification
            {
                Body = s.Notification.Body,
                Title = s.Notification.Title
            },
            Data = s.Data,
            Topic = s.Topic,
            Token = s.Token,
            Condition = s.Condition
        });
        return await FirebaseMessaging.DefaultInstance.SendAllAsync(messages, cts.Token);
    }
    public CloudMessaging(string baseUrl, GoogleCredential credential) : base(baseUrl, configureDefaultHeaders: async headers =>
    {
        var cts = new CancellationTokenSource();

        headers.Add(KnownHeaders.Authorization, $"Bearer {await credential.UnderlyingCredential.GetAccessTokenForRequestAsync(cancellationToken: cts.Token)}");
    })
    {
        route = $"v1/projects/{((ServiceAccountCredential)credential.UnderlyingCredential).ProjectId}/messages:send";
    }
    readonly string route;
    readonly CancellationTokenSource cts = new();
}