using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Google;

public class GoogleUser
{
    [DataMember, JsonProperty("id")]
    public string? Id
    {
        get; set;
    }
    [DataMember, JsonProperty("email")]
    public string? Email
    {
        get; set;
    }
    [DataMember, JsonProperty("verified_email")]
    public bool IsVerifiedEmail
    {
        get; set;
    }
    [DataMember, JsonProperty("name")]
    public string? Name
    {
        get; set;
    }
    [DataMember, JsonProperty("given_name")]
    public string? GivenName
    {
        get; set;
    }
    [DataMember, JsonProperty("family_name")]
    public string? FamilyName
    {
        get; set;
    }
    [DataMember, JsonProperty("picture")]
    public string? Image
    {
        get; set;
    }
    [DataMember, JsonProperty("locale")]
    public string? Locale
    {
        get; set;
    }
}