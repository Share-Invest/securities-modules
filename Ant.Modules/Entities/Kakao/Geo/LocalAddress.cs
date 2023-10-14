using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShareInvest.Entities.Kakao.Geo;

public struct LocalAddress
{
    [DataMember, JsonProperty("meta")]
    public Meta Meta
    {
        get; set;
    }
    [DataMember, JsonProperty("documents")]
    public Response[] Document
    {
        get; set;
    }
}