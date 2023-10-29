using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace ShareInvest.Entities.Naver;

public struct TranslateResult
{
    [DataMember, JsonProperty("srcLangType")]
    public string SrcLangType
    {
        get; set;
    }
    [DataMember, JsonProperty("tarLangType")]
    public string TarLangType
    {
        get; set;
    }
    [DataMember, JsonProperty("translatedText")]
    public string TranslatedText
    {
        get; set;
    }
}