using Newtonsoft.Json.Linq;

using ShareInvest.Entities.Assets;
using ShareInvest.OpenAPI.Entity;
using ShareInvest.Properties;

namespace ShareInvest.Observers;

public class TrMsgEventArgs : MsgEventArgs
{
    public TrMsgEventArgs(string hubMethodName, string json)
    {
        HubMethodName = hubMethodName;
        Json = json;
    }
    public TrMsgEventArgs(TR tr, string json)
    {
        HubMethodName = tr switch
        {
            OPTKWFID or Opt10004 => tr.GetType().Name,

            OPW00004 => determineTheNameOPW4(json),
            Opw00005 => determineTheNameOPW5(json),

            _ => throw new NotImplementedException(nameof(TR))
        };
        Json = json;
    }
    public string HubMethodName
    {
        get;
    }
    public string Json
    {
        get;
    }
    readonly Func<string, string> determineTheNameOPW4 = json =>
    {
        var isExist = JObject.Parse(json).AsJEnumerable().Any(predicate => Resources.STOCKCODE.Equals(predicate.Path));

        return isExist ? nameof(BalOPW00004) : nameof(AccOPW00004);
    };
    readonly Func<string, string> determineTheNameOPW5 = json =>
    {
        var isExist = JObject.Parse(json).AsJEnumerable().Any(predicate => Resources.CODENUMBER.Equals(predicate.Path));

        return isExist ? nameof(BalOPW00005) : nameof(AccOPW00005);
    };
}