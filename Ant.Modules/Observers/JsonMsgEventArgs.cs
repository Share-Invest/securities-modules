using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShareInvest.Entities.Assets;
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

            Opt10081 => JsonConvert.DeserializeObject<MultiOpt10081>(json),

            Opt10004 => JsonConvert.DeserializeObject<Entities.Kiwoom.Opt10004>(json),
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

        return isExist ? JsonConvert.DeserializeObject<BalOPW00004>(json) : JsonConvert.DeserializeObject<AccOPW00004>(json);
    };
    readonly Func<string, IAccountBook?> deserializeOPW5 = json =>
    {
        var isExist = JObject.Parse(json).AsJEnumerable().Any(predicate => Resources.CODENUMBER.Equals(predicate.Path));

        return isExist ? JsonConvert.DeserializeObject<BalOPW00005>(json) : JsonConvert.DeserializeObject<AccOPW00005>(json);
    };
}