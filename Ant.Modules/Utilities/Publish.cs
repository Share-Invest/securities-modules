using Newtonsoft.Json;

using System.Diagnostics;

namespace ShareInvest.Utilities;

public class Publish
{
    public async Task ExecuteAsync(string program, string commandLine)
    {
        CommandLine = commandLine;

        foreach (var info in GetVersionInfo(program))
        {
            var index = info.FileName.IndexOf(nameof(Publish).ToLowerInvariant());

            if (index < 0)
            {
                continue;
            }
        }
    }
    public Publish(string path)
    {
        this.path = path;
    }
    IEnumerable<FileVersionInfo> GetVersionInfo(string fileName)
    {
        string? dirName = string.Empty;

        foreach (var file in Directory.EnumerateFiles(path, fileName, SearchOption.AllDirectories))
        {
            var info = FileVersionInfo.GetVersionInfo(file);

            if (string.IsNullOrEmpty(Parameter.CompanyName) is false && Parameter.CompanyName.Equals(info.CompanyName))
            {
                dirName = Path.GetDirectoryName(info.FileName);

                if (string.IsNullOrEmpty(dirName) is false && dirName.EndsWith(nameof(Publish), StringComparison.OrdinalIgnoreCase))
                {
#if DEBUG
                    Debug.WriteLine(JsonConvert.SerializeObject(info, Formatting.Indented));

                    Build(dirName);
#endif
                    break;
                }
            }
        }
        foreach (var file in Directory.EnumerateFiles(dirName, "*", SearchOption.AllDirectories))
        {
#if DEBUG
            Debug.WriteLine(file);
#endif
            yield return FileVersionInfo.GetVersionInfo(file);
        }
    }
    void Build(string workingDirectory)
    {
        DirectoryInfo? directoryInfo;

        while (workingDirectory.Length > 0)
        {
            directoryInfo = Directory.GetParent(workingDirectory);

            if (directoryInfo != null)
            {
                workingDirectory = directoryInfo.FullName;

                if (directoryInfo?.GetFiles(Properties.Resources.CSPROJ, SearchOption.TopDirectoryOnly).Length > 0)
                {
                    break;
                }
            }
        }
        using (var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                Verb = Properties.Resources.ADMIN,
                FileName = Properties.Resources.POWERSHELL,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        })
        {
#if DEBUG
            process.OutputDataReceived += (sender, e) =>
            {
                Debug.WriteLine(e.Data);
            };
#endif
            if (process.Start())
            {
                process.BeginOutputReadLine();
                process.StandardInput.Write(CommandLine + Environment.NewLine);
                process.StandardInput.Close();
                process.WaitForExit();
            }
        }
    }
    string? CommandLine
    {
        get; set;
    }
    readonly string path;
}