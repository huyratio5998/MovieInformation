using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieInformation.Services.ApiModels.Responses
{
    public partial class MovieKeywordRespone
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("keywords")]
        public Keyword[] Keywords { get; set; }
    }

    public partial class Keyword
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
