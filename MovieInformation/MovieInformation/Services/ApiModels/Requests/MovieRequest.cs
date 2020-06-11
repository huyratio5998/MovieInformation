using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieInformation.Services.ApiModels.Requests
{
    public class MovieRequest
    {
        // for get movie detail
        [JsonProperty("movie_id")]
        public string Movie_id { get; set; }

        [JsonProperty("api_key")]
        public string Api_key { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("append_to_response")]
        public string Append_to_response { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }
        [JsonProperty("include_image_language")]
        public int? Include_image_language { get; set; }
        [JsonProperty("guest_session_id")]
        public string Guest_session_id { get; set; }

        public string TrendingTime { get; set; }

    }
}
