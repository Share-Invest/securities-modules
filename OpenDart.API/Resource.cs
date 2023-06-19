using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ShareInvest.Entities;

using System.Diagnostics;
using System.IO.Compression;
using System.Text;

namespace ShareInvest;

static class Resource
{
    internal static string ToJson(byte[]? rawBytes, string? content)
    {
        using (var stream = new MemoryStream(rawBytes ?? Array.Empty<byte>()))
        {
            try
            {
                using (var compress = new ZipArchive(stream, ZipArchiveMode.Read))
                {
                    var list = new Stack<DartCode>();

                    foreach (var entry in compress.Entries)
                    {
                        using (var sr = new StreamReader(entry.Open()))
                        {
                            var xml = new System.Xml.XmlDocument();

                            xml.LoadXml(sr.ReadToEnd());

                            foreach (System.Xml.XmlNode node in xml.GetElementsByTagName(nameof(list)))
                            {
                                if (string.IsNullOrEmpty(node["stock_code"]?.InnerText))
                                {
                                    continue;
                                }
                                else
                                {
                                    list.Push(new DartCode
                                    {
                                        StockCode = node["stock_code"]?.InnerText,
                                        CorpCode = node["corp_code"]?.InnerText,
                                        CorpName = node["corp_name"]?.InnerText,
                                        ModifyDate = node["modify_date"]?.InnerText
                                    });
                                }
                            }
                        }
                    }
                    return JsonConvert.SerializeObject(list, Formatting.Indented);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return GetMessage(content ?? string.Empty);
            }
        }
    }
    internal static string Get(string resource, JToken? token = null)
    {
        if (token == null)
        {
            return resource;
        }
        StringBuilder query = new("?");

        foreach (var j in token.Children<JProperty>())

            if (JTokenType.Null != j.Value.Type)
            {
                query.Append(j.Path);
                query.Append('=');
                query.Append(j.Value);
                query.Append('&');
            }
        return string.Concat(resource, query.Remove(query.Length - 1, 1));
    }
    static string GetMessage(string message)
    {
        var xml = new System.Xml.XmlDocument();

        xml.LoadXml(message);

        foreach (System.Xml.XmlNode node in xml.GetElementsByTagName(nameof(message)))
        {
            if (string.IsNullOrEmpty(node.InnerText))
            {
                continue;
            }
            return node.InnerText;
        }
        return string.Empty;
    }
}