using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieInformation.Services.ApiModels.Responses
{
    public class GuessSessionResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("guest_session_id")]
        public string Guest_session_id { get; set; }

        [JsonProperty("expires_at")]
        public string Expires_at { get; set; }

    }
}
