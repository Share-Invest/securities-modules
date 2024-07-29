using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google.Firebase;

public struct Notification
{
    [DataMember, JsonProperty("title")]
    public string Title
    {
        get; set;
    }

    [DataMember, JsonProperty("body")]
    public string Body
    {
        get; set;
    }

    [DataMember, JsonProperty("image")]
    public string ImageUrl
    {
        get; set;
    }
}