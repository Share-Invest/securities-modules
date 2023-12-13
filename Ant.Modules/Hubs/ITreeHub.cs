using ShareInvest.Entities;

namespace ShareInvest.Hubs;

public interface ITreeHub
{
    Task<TreeMapStock[]> GetStocksAsync();
}