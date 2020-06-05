using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieInformation.Services.ApiModels.Requests
{
    public class SearchRequest
    {

        [JsonProperty("api_key")]
        public string Api_key { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }


        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("page")]
        public string Page { get; set; }

        [JsonProperty("include_adult")]
        public string Include_adult { get; set; }

        [JsonProperty("region")]
        public int? Region { get; set; }
        [JsonProperty("year")]
        public int? Year { get; set; }
        [JsonProperty("primary_release_year")]
        public int? Primary_release_year { get; set; }
    }
}
