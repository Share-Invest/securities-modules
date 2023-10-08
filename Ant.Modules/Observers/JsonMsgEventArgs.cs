using Newtonsoft.Json;

using ShareInvest.Entities;

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
            Entities.Kiwoom.OPTKWFID => JsonConvert.DeserializeObject<OPTKWFID>(json),

            _ => throw new InvalidCastException($"{tr?.TrCode} can't be cast.")
        };
    }
}