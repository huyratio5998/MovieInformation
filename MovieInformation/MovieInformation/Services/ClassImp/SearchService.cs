using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;

namespace MovieInformation.Services.ClassImp
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _httpClient;

        public SearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<SearchKeywordsResponse> SearchKeywords(SearchRequest request)
        {
            string uri = $"search/keyword?api_key={request.Api_key}&query={request.Query}&page={request.Page}";
            return ApiHelper.GetMovieApi<SearchKeywordsResponse>(uri, _httpClient);
        }

        public Task<SearchMoviesResponse> SearchMovies(SearchRequest request)
        {
            string uri = $"search/movie?api_key={request.Api_key}&language={request.Language}&query={request.Query}&page={request.Page}&include_adult=" +
                         $"{request.Include_adult}&region={request.Region}&year={request.Year}&primary_release_year={request.Primary_release_year}";
            return ApiHelper.GetMovieApi<SearchMoviesResponse>(uri, _httpClient);
        }
    }
}
