using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieInformation.Services.ClassImp
{
    public class GenreService : IGenreService
    {
        private readonly HttpClient _httpClient;

        public GenreService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }      

        public Task<GenreResponse> GetListGenre(SearchRequest request)
        {
            string uri = $"genre/movie/list?api_key={request.Api_key}&language={request.Language}";
            return ApiHelper.GetMovieApi<GenreResponse>(uri, _httpClient);
        }       
    }
}
