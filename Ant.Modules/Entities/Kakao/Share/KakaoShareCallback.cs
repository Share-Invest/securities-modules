using ShareInvest.Entities.Google.Maps;

namespace ShareInvest.Entities.Kakao.Share;

public struct KakaoShareCallback
{
    public string? CHAT_TYPE
    {
        get; set;
    }
    public string? HASH_CHAT_ID
    {
        get; set;
    }
    public long TEMPLATE_ID
    {
        get; set;
    }
    public Coordinate Key
    {
        get; set;
    }
}