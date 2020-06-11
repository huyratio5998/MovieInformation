using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;
using Newtonsoft.Json;

namespace MovieInformation.Services.ClassImp
{
    public class ApiHelper
    {       

        public static async Task<T> GetMovieApi<T>( string uri, HttpClient httpClient) where T: class
        {
            try
            {
                var responObj = await httpClient.GetStringAsync(uri);
                var result = JsonConvert.DeserializeObject<T>(responObj);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }      
    }
}
