using ShareInvest.Entities.Dart;

namespace ShareInvest.Repositories;

public interface ICompanyRepository : IDisposable
{
    Task<(bool isUnique, double latitude, double longitude)> IsUniqueAsync(string code, string address);

    bool AnyDuplicateCoordinates(double longitude, double latitude);

    int AddOrUpdateCompanyOverview(CompanyOverview companyOverview);
}