﻿using System.Text.RegularExpressions;

namespace ShareInvest;

public static partial class Parameter
{
    public static string TransformOutbound(string route)
    {
        return Regex.Replace(route, "([a-z])([A-Z])", "$1-$2", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(0x64))
                    .ToLowerInvariant();
    }
    public static string TransformInbound(string? query)
    {
        if (string.IsNullOrEmpty(query) is false)
        {
            var str = TransformRegex().Replace(query, o => o.Groups[1].Value.ToUpper());

            return string.Concat(char.ToUpper(str[0]), str[1..]);
        }
        return string.Empty;
    }
    public static void CreateDirectoryIsNotExist(string path)
    {
        if (Path.GetDirectoryName(path) is string directory)
        {
            DirectoryInfo di = new(directory);

            if (di.Exists is false)
            {
                di.Create();
            }
        }
    }
    [GeneratedRegex("-([a-z])")]
    private static partial Regex TransformRegex();
}