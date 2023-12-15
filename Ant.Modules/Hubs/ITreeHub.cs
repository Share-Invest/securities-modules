using ShareInvest.Entities;

namespace ShareInvest.Hubs;

public interface ITreeHub
{
    Task<TreeMapStock[]> GetStocksCategorizedByTheme(HighGrowthRateTheme[] themeGroup);

    Task<HighGrowthRateTheme[]> GetThemesWithHighGrowthRateAsync();
}