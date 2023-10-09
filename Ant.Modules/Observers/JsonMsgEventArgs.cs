using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShareInvest.Entities;
using ShareInvest.Entities.Assets;
using ShareInvest.Properties;

namespace ShareInvest.Observers;

public class JsonMsgEventArgs : MsgEventArgs
{
    public object? Convey
    {
        get;
    }
    public JsonMsgEventArgs(Entities.Kiwoom.TR tr, string json)
    {
        Convey = tr switch
        {
            Entities.Kiwoom.OPW00004 => deserializeOPW4(json),

            Entities.Kiwoom.OPW00005 => deserializeOPW5(json),

            Entities.Kiwoom.OPTKWFID => JsonConvert.DeserializeObject<OPTKWFID>(json),

            _ => throw new InvalidCastException($"{tr.TrCode} can't be cast.")
        };
    }
    public JsonMsgEventArgs(Entities.Kiwoom.TR tr)
    {
        Convey = tr;
    }
    readonly Func<string, AccountBook?> deserializeOPW4 = json =>
    {
        var isExist = JObject.Parse(json).AsJEnumerable().Any(predicate => Resources.STOCKCODE.Equals(predicate.Path));

        return isExist ? JsonConvert.DeserializeObject<BalOPW00004>(json) : JsonConvert.DeserializeObject<AccOPW00004>(json);
    };
    readonly Func<string, AccountBook?> deserializeOPW5 = json =>
    {
        var isExist = JObject.Parse(json).AsJEnumerable().Any(predicate => Resources.CODENUMBER.Equals(predicate.Path));

        return isExist ? JsonConvert.DeserializeObject<BalOPW00005>(json) : JsonConvert.DeserializeObject<AccOPW00005>(json);
    };
}