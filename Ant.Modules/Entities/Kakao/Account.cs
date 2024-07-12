using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ShareInvest.Entities.Kakao;

public class Account
{
    [JsonProperty("profile"), JsonPropertyName("profile"), DataMember]
    public Profile? Profile
    {
        get; set;
    }

    [JsonProperty("gender"), JsonPropertyName("gender"), DataMember]
    public string? Gender
    {
        get; set;
    }

    [JsonProperty("birthday_type"), JsonPropertyName("birthday_type"), DataMember]
    public string? BirthdayType
    {
        get; set;
    }

    [JsonProperty("birthday"), JsonPropertyName("birthday"), DataMember]
    public string? Birthday
    {
        get; set;
    }

    [JsonProperty("age_range"), JsonPropertyName("age_range"), DataMember]
    public string? AgeRange
    {
        get; set;
    }

    [JsonProperty("email"), JsonPropertyName("email"), DataMember]
    public string? Email
    {
        get; set;
    }

    [DataMember, JsonProperty("profile_nickname_needs_agreement"), JsonPropertyName("profile_nickname_needs_agreement"), NotMapped]
    public bool NickNameAgreement
    {
        get; set;
    }

    [DataMember, JsonProperty("profile_image_needs_agreement"), JsonPropertyName("profile_image_needs_agreement"), NotMapped]
    public bool ImageAgreement
    {
        get; set;
    }

    [DataMember, JsonProperty("has_email"), JsonPropertyName("has_email"), NotMapped]
    public bool HasEmail
    {
        get; set;
    }

    [DataMember, JsonProperty("email_needs_agreement"), JsonPropertyName("email_needs_agreement"), NotMapped]
    public bool EmailAgreement
    {
        get; set;
    }

    [DataMember, JsonProperty("is_email_valid"), JsonPropertyName("is_email_valid"), NotMapped]
    public bool IsEmailValid
    {
        get; set;
    }

    [DataMember, JsonProperty("is_email_verified"), JsonPropertyName("is_email_verified"), NotMapped]
    public bool IsEmailVerified
    {
        get; set;
    }

    [DataMember, JsonProperty("has_age_range"), JsonPropertyName("has_age_range"), NotMapped]
    public bool HasAgeRange
    {
        get; set;
    }

    [DataMember, JsonProperty("age_range_needs_agreement"), JsonPropertyName("age_range_needs_agreement"), NotMapped]
    public bool AgeRangeAgreement
    {
        get; set;
    }

    [DataMember, JsonProperty("has_birthday"), JsonPropertyName("has_birthday"), NotMapped]
    public bool HasBirthday
    {
        get; set;
    }

    [DataMember, JsonProperty("birthday_needs_agreement"), JsonPropertyName("birthday_needs_agreement"), NotMapped]
    public bool BirthdayAgreement
    {
        get; set;
    }

    [DataMember, JsonProperty("has_gender"), JsonPropertyName("has_gender"), NotMapped]
    public bool HasGender
    {
        get; set;
    }

    [DataMember, JsonProperty("gender_needs_agreement"), JsonPropertyName("gender_needs_agreement"), NotMapped]
    public bool GenderAgreement
    {
        get; set;
    }
}