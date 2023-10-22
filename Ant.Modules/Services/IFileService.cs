using ShareInvest.Entities;

namespace ShareInvest.Services;

public interface IFileService
{
    IEnumerable<FileVersionInfo>? GetFileVersions(string app);

    Task<FileInfo?> Save(FileVersionInfo fileVersionInfo);

    Task<FileVersionInfo?> CheckFileVersions(string app, string name, string path);
}