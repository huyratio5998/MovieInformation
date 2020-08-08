using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;

namespace MovieInformation.Services.Interfaces
{
    public interface IUserSessionService
    {
        Task<GuessSessionResponse> CreateGuessSession(MovieRequest request);
        Task<RatedMoviesResponse> GetRatedMovie(MovieRequest request, string sortBy);
    }
}
