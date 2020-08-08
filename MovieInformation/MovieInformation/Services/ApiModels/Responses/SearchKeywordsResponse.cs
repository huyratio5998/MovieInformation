using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieInformation.Services.ApiModels.Responses
{
    public partial class SearchKeywordsResponse
    {
        [JsonProperty("page")]
        public long Page { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("total_results")]
        public long TotalResults { get; set; }
    }

}
