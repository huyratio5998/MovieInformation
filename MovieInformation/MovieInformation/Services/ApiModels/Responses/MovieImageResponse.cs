using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieInformation.Services.ApiModels.Responses
{
    public partial class MovieImageResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("backdrops")]
        public Backdrop[] Backdrops { get; set; }

        [JsonProperty("posters")]
        public Backdrop[] Posters { get; set; }
    }

    public partial class Backdrop
    {
        [JsonProperty("aspect_ratio")]
        public double AspectRatio { get; set; }

        [JsonProperty("file_path")]
        public string FilePath { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso639_1 { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long VoteCount { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }
}
