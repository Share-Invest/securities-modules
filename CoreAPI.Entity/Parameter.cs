using Newtonsoft.Json.Linq;

using System.Text;
using System.Text.RegularExpressions;

namespace ShareInvest;

public static class Parameter
{
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
    public static string TransformOutbound(string route) =>

        Regex.Replace(route,
                      "([a-z])([A-Z])",
                      "$1-$2",
                      RegexOptions.CultureInvariant,
                      TimeSpan.FromMilliseconds(0x64))
             .ToLowerInvariant();
}