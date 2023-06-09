using ShareInvest.Properties;

using System.Diagnostics;
using System.IO.Compression;

namespace ShareInvest
{
    public static class Ax
    {
        public static void Install()
        {
            var directory = new DirectoryInfo(Resources.PATH);

            if (directory.Exists is false)
            {
                directory.Create();
            }
            var path = directory.FullName;

            var fileFullName = Path.Combine(path, Resources.ZIP);

            File.WriteAllBytes(fileFullName, Resources.OpenAPIx64);

            ZipFile.ExtractToDirectory(fileFullName, path, true);

            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Resources.INSTALL,
                    WorkingDirectory = path,
                    Verb = Resources.ADMIN,
                    UseShellExecute = true,
                    CreateNoWindow = true
                }
            })
            {
                if (process.Start())
                {
                    process.WaitForExit();
                }
            }
            File.Delete(fileFullName);
        }
    }
}