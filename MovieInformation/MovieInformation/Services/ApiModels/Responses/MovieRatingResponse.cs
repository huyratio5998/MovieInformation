using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieInformation.Services.ApiModels.Responses
{
    public class MovieRatingResponse
    {
        [JsonProperty("status_code")]
        public int Status_code { get; set; }

        [JsonProperty("status_message")]
        public string Status_message { get; set; }

       
    }
}
