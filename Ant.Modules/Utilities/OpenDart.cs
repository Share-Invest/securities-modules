﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RestSharp;

using ShareInvest.Entities.Dart;

using System.IO.Compression;
using System.Net;
using System.Xml;

namespace ShareInvest.Utilities;

public class OpenDart : RestClient
{
    public async IAsyncEnumerable<UniqueNumber> GetCorpCodeAsync()
    {
        var query = Parameter.TransformQuery(JToken.FromObject(new
        {
            crtfc_key = openDartKey
        }));
        if ((await ExecuteAsync(new RestRequest(string.Concat(corpCode, query)), cts.Token)).RawBytes is byte[] rawBytes)
        {
            using (var stream = new MemoryStream(rawBytes))
            {
                using (var compress = new ZipArchive(stream, ZipArchiveMode.Read))
                {
                    foreach (var entry in compress.Entries)
                    {
                        using (var sr = new StreamReader(entry.Open()))
                        {
                            var xml = new XmlDocument();

                            xml.LoadXml(sr.ReadToEnd());

                            foreach (XmlNode node in xml.GetElementsByTagName("list"))
                            {
                                if (string.IsNullOrEmpty(node["stock_code"]?.InnerText))
                                {
                                    continue;
                                }
                                yield return new UniqueNumber
                                {
                                    Code = node["stock_code"]?.InnerText,
                                    CorpCode = node["corp_code"]?.InnerText,
                                    CorpName = node["corp_name"]?.InnerText,
                                    ModifyDate = node["modify_date"]?.InnerText
                                };
                            }
                        }
                    }
                }
            }
        }
    }
    public async Task<CompanyOverview?> GetCompanyOverviewAsync(string corpCode)
    {
        var query = Parameter.TransformQuery(JToken.FromObject(new
        {
            crtfc_key = openDartKey,
            corp_code = corpCode
        }));
        var response = await ExecuteAsync(new RestRequest(string.Concat(company, query)), cts.Token);

        if (HttpStatusCode.OK == response.StatusCode && string.IsNullOrEmpty(response.Content) is false)
        {
            return JsonConvert.DeserializeObject<CompanyOverview>(response.Content);
        }
        return null;
    }
    public OpenDart(string openDartKey) : base("https://opendart.fss.or.kr")
    {
        this.openDartKey = openDartKey;
    }
    readonly CancellationTokenSource cts = new();
    readonly string openDartKey;

    const string corpCode = "api/corpCode.xml";
    const string company = "api/company.json";
}