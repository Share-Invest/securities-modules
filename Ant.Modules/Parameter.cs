using Newtonsoft.Json.Linq;

using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ShareInvest;

public static partial class Parameter
{
    [Conditional("DEBUG")]
    public static void GetProperites<T>(T property) where T : class
    {
        foreach (var propertyInfo in property.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            Debug.WriteLine($"{propertyInfo.Name}: {propertyInfo.GetValue(property)}");
        }
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
    public static string TransformQuery(JToken token, StringBuilder query)
    {
        query.Append('?');

        foreach (var j in token.Children<JProperty>())

            if (JTokenType.Null != j.Value.Type)
            {
                query.Append(j.Path);
                query.Append('=');
                query.Append(j.Value);
                query.Append('&');
            }
        return TransformOutbound(query.Remove(query.Length - 1, 1).ToString());
    }
    public static string TransformQuery(JToken token)
    {
        StringBuilder query = new("?");

        foreach (var j in token.Children<JProperty>())

            if (JTokenType.Null != j.Value.Type)
            {
                query.Append(j.Path);
                query.Append('=');
                query.Append(j.Value);
                query.Append('&');
            }
        return query.Remove(query.Length - 1, 1).ToString();
    }
    public static string TransformOutbound(string route)
    {
        return Regex.Replace(route, "([a-z])([A-Z])", "$1-$2", RegexOptions.CultureInvariant, TimeSpan.FromMilliseconds(0x64)).ToLowerInvariant();
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
    [GeneratedRegex("-([a-z])")]
    private static partial Regex TransformRegex();
}