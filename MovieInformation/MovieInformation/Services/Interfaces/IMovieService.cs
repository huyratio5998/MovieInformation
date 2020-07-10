using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MovieInformation.Services.ApiModels;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;

namespace MovieInformation.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieDetailResponse> GetMovieDetail(MovieRequest request);
        Task<MoviePopularResponse> GetPopularMovies(MovieRequest request);
        Task<MoviePopularResponse> GetUpcomingMovies(MovieRequest request);
        Task<MoviePopularResponse> GetTrending(MovieRequest request);
        Task<MoviePopularResponse> GetNowPlayingMovies(MovieRequest request);
        Task<MoviePopularResponse> GetTopRateMovies(MovieRequest request);        
        Task<MovieCreditsResponse> GetCreditsMovies(MovieRequest request);
        Task<MovieImageResponse> GetImagesMovies(MovieRequest request);
        Task<MovieKeywordRespone> GetKeywordMovies(MovieRequest request);
        Task<MovieVideoResponse> GetVideosMovies(MovieRequest request);
        Task<MoviePopularResponse> GetRecommendationsMovies(MovieRequest request);
        Task<MoviePopularResponse> GetSimilarMovies(MovieRequest request);        
        Task<MovieRatingResponse> RatingMovies(MovieRequest request, double rating);
        //
        Task<List<MovieDetailResponse>> GetListMovieDetailsByListMovieId(List<string> movieIds);
    }
}
    