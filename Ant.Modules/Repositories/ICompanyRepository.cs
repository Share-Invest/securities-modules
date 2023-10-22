using ShareInvest.Entities.Dart;

namespace ShareInvest.Repositories;

public interface ICompanyRepository
{
    Task<(bool isUnique, double latitude, double longitude)> IsUniqueAsync(string code, string address);

    Task<bool> IfExistsAsync(string serialNumber);

    bool AnyDuplicateCoordinates(double longitude, double latitude);

    int AddOrUpdateCompanyOverview(CompanyOverview companyOverview);

    int HasBeenIssued(Disclousure disclousure);
}