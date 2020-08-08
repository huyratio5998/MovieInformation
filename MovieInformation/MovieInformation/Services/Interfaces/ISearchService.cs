using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;

namespace MovieInformation.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchKeywordsResponse> SearchKeywords(SearchRequest request);
        Task<SearchMoviesResponse> SearchMovies(SearchRequest request);
    }
}
