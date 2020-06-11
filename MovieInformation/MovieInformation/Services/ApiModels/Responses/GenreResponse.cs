using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Services.ApiModels.Responses
{  
    public partial class GenreResponse
    {
        [JsonProperty("genres")]
        public Genre[] Genres { get; set; }
    }  
}
