using Newtonsoft.Json;

using ShareInvest.Entities.Identity;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Entities.Google;

public class GoogleUser : DeviceIdentity
{
    [DataMember, JsonProperty("id"), JsonPropertyName("id")]
    public string? Id
    {
        get; set;
    }

    [DataMember, JsonProperty("email"), JsonPropertyName("email")]
    public string? Email
    {
        get; set;
    }

    [DataMember, JsonProperty("verified_email"), JsonPropertyName("verified_email")]
    public bool IsVerifiedEmail
    {
        get; set;
    }

    [DataMember, JsonProperty("name"), JsonPropertyName("name")]
    public string? Name
    {
        get; set;
    }

    [DataMember, JsonProperty("given_name"), JsonPropertyName("given_name")]
    public string? GivenName
    {
        get; set;
    }

    [DataMember, JsonProperty("family_name"), JsonPropertyName("family_name")]
    public string? FamilyName
    {
        get; set;
    }

    [DataMember, JsonProperty("picture"), JsonPropertyName("picture")]
    public string? Image
    {
        get; set;
    }

    [DataMember, JsonProperty("locale"), JsonPropertyName("locale")]
    public string? Locale
    {
        get; set;
    }
}