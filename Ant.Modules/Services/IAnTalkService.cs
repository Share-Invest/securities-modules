using ShareInvest.Entities.AnTalk;
using ShareInvest.Services.AnTalk;

namespace ShareInvest.Services;

public interface IAnTalkService
{
    Task<AntStock[]> GetStockAsync(Order order);
}