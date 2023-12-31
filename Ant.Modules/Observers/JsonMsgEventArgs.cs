using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShareInvest.OpenAPI.Entity;
using ShareInvest.Properties;

namespace ShareInvest.Observers;

public class JsonMsgEventArgs : MsgEventArgs
{
    public object? Convey
    {
        get;
    }
    public JsonMsgEventArgs(TR tr, string json)
    {
        Convey = tr switch
        {
            OPW00004 => deserializeOPW4(json),
            Opw00005 => deserializeOPW5(json),

            Opw20007 => JsonConvert.DeserializeObject<Entities.Assets.Opw20007>(json),
            OPW20010 => JsonConvert.DeserializeObject<Entities.Assets.OPW20010>(json),

            Opt10081 => JsonConvert.DeserializeObject<MultiOpt10081>(json),

            Opt10080 => JsonConvert.DeserializeObject<Entities.Kiwoom.Opt10080>(json),
            Opt10004 => JsonConvert.DeserializeObject<Entities.Kiwoom.Opt10004>(json),
            Opt50001 => JsonConvert.DeserializeObject<Entities.Kiwoom.Opt50001>(json),
            Opt50029 => JsonConvert.DeserializeObject<Entities.Kiwoom.Opt50029>(json),
            Opt50030 => JsonConvert.DeserializeObject<Entities.Kiwoom.Opt50030>(json),
            OPTKWFID => JsonConvert.DeserializeObject<Entities.Kiwoom.OPTKWFID>(json),

            _ => JsonConvert.DeserializeObject(json, tr.GetType())
        };
    }
    public JsonMsgEventArgs(TR tr)
    {
        Convey = tr;
    }
    readonly Func<string, IAccountBook?> deserializeOPW4 = json =>
    {
        var isExist = JObject.Parse(json).AsJEnumerable().Any(predicate => Resources.STOCKCODE.Equals(predicate.Path));

        return isExist ? JsonConvert.DeserializeObject<Entities.Assets.BalOPW00004>(json) : JsonConvert.DeserializeObject<Entities.Assets.AccOPW00004>(json);
    };
    readonly Func<string, IAccountBook?> deserializeOPW5 = json =>
    {
        var isExist = JObject.Parse(json).AsJEnumerable().Any(predicate => Resources.CODENUMBER.Equals(predicate.Path));

        return isExist ? JsonConvert.DeserializeObject<Entities.Assets.BalOPW00005>(json) : JsonConvert.DeserializeObject<Entities.Assets.AccOPW00005>(json);
    };
}