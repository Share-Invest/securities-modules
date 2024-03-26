using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RestSharp;

using ShareInvest.Entities;

using System.Net;

namespace ShareInvest.Utilities;

public class FinancialSummary : RestClient
{
    public static async Task<FinancialStatements[]> ExecuteAsync(string code)
    {
        using (var client = new RestClient(URL))
        {
            var resource = new RestRequest($"company/ajax/c1050001_data.aspx?flag=2&cmp_cd={code}&finGubun=MAIN&frq=0");

            var response = await client.ExecuteAsync(resource);

            if (HttpStatusCode.OK != response.StatusCode || string.IsNullOrEmpty(response.Content))
            {
                return [];
            }
            var data = JToken.Parse(response.Content)["JsonData"];

            if (data == null || !data.HasValues)
            {
                return [];
            }
            var json = Convert.ToString(data);

            if (string.IsNullOrEmpty(json))
            {
                return [];
            }
            return JsonConvert.DeserializeObject<FinancialStatements[]>(json) ?? [];
        }
    }

    const string URL = "https://navercomp.wisereport.co.kr";
}