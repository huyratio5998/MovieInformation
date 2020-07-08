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
    public class UserSessionService : IUserSessionService
    {
        private readonly HttpClient _httpClient;

        public UserSessionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<GuessSessionResponse> CreateGuessSession(MovieRequest request)
        {

            string uri = $"authentication/guest_session/new?api_key={request.Api_key}";
            return ApiHelper.GetMovieApi<GuessSessionResponse>(uri, _httpClient);
        }
        public Task<RatedMoviesResponse> GetRatedMovie(MovieRequest request, string sortBy)
        {

            string uri = $"/guest_session/{request.Guest_session_id}/rated/movies? api_key = {request.Api_key} & language = {request.Language} & sort_by = {sortBy}";
            return ApiHelper.GetMovieApi<RatedMoviesResponse>(uri, _httpClient);
        }
        
    }
}
