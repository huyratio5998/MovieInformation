using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieInformation.Services.ApiModels;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MovieInformation.Services.ClassImp
{
    public class MovieService : IMovieService 
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string _api_key;

        public MovieService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
            _api_key = _config.GetValue<string>("AppSettings:Api_Key");
        }
        [HttpGet]
        public  Task<MovieDetailResponse> GetMovieDetail(MovieRequest request)
        {
            string uri = $"movie/{request.Movie_id}?api_key={request.Api_key}&language={request.Language}&include_image_language={request.Include_image_language}";
            return ApiHelper.GetMovieApi<MovieDetailResponse>(uri, _httpClient);
        }
        public  Task<MoviePopularResponse> GetPopularMovies(MovieRequest request)
        {
            string uri = $"movie/popular?api_key={request.Api_key}&language={request.Language}&page={request.Page}&region={request.Region}";
            return  ApiHelper.GetMovieApi<MoviePopularResponse>(uri,_httpClient);
        }

        public  Task<MoviePopularResponse> GetTopRateMovies(MovieRequest request)
        {
            string uri = $"movie/top_rated?api_key={request.Api_key}&language={request.Language}&page={request.Page}&region={request.Region}";
            return  ApiHelper.GetMovieApi<MoviePopularResponse>(uri, _httpClient);
        }

        public  Task<MovieCreditsResponse> GetCreditsMovies(MovieRequest request)
        {
            string uri = $"movie/{request.Movie_id}/credits?api_key={request.Api_key}";
            return  ApiHelper.GetMovieApi<MovieCreditsResponse>(uri, _httpClient);
        }

        public Task<MovieImageResponse> GetImagesMovies(MovieRequest request)
        {
            string uri = $"movie/{request.Movie_id}/images?api_key={request.Api_key}&language={request.Language}&include_image_language={request.Include_image_language}";
            return ApiHelper.GetMovieApi<MovieImageResponse>(uri, _httpClient);
        }

        public Task<MovieKeywordRespone> GetKeywordMovies(MovieRequest request)
        {
            string uri = $"movie/{request.Movie_id}/keywords?api_key={request.Api_key}";
            return ApiHelper.GetMovieApi<MovieKeywordRespone>(uri, _httpClient);
        }

        public Task<MovieVideoResponse> GetVideosMovies(MovieRequest request)
        {
            string uri = $"movie/{request.Movie_id}/videos?api_key={request.Api_key}&language={request.Language}";
            return ApiHelper.GetMovieApi<MovieVideoResponse>(uri, _httpClient);
        }

        public Task<MoviePopularResponse> GetRecommendationsMovies(MovieRequest request)
        {
            string uri = $"movie/{request.Movie_id}/recommendations?api_key={request.Api_key}&language={request.Language}&page={request.Page}";
            return ApiHelper.GetMovieApi<MoviePopularResponse>(uri, _httpClient);
        }

        public Task<MoviePopularResponse> GetSimilarMovies(MovieRequest request)
        {
            string uri = $"movie/{request.Movie_id}/similar?api_key={request.Api_key}&language={request.Language}&page={request.Page}";
            return ApiHelper.GetMovieApi<MoviePopularResponse>(uri, _httpClient);
        }
        [HttpPost]
        public async Task<MovieRatingResponse> RatingMovies(MovieRequest request, double rating)
        {
            string uri = $"movie/{request.Movie_id}/rating?api_key={request.Api_key}&guest_session_id={request.Guest_session_id}";
            try
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("value", $"{rating}")
                });
                var ratingPost = await _httpClient.PostAsync(uri,content);
                
                if (ratingPost.IsSuccessStatusCode)
                {
                    string resultContent = await ratingPost.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<MovieRatingResponse>(resultContent);
                    return result;
                }

                return new MovieRatingResponse();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<MoviePopularResponse> GetNowPlayingMovies(MovieRequest request)
        {
            string uri = $"movie/now_playing?api_key={request.Api_key}&language={request.Language}&page={request.Page}&region={request.Region}";
            return ApiHelper.GetMovieApi<MoviePopularResponse>(uri, _httpClient);
        }

        public Task<MoviePopularResponse> GetUpcomingMovies(MovieRequest request)
        {
            string uri = $"movie/upcoming?api_key={request.Api_key}&language={request.Language}&page={request.Page}&region={request.Region}";
            return ApiHelper.GetMovieApi<MoviePopularResponse>(uri, _httpClient);
        }

        public Task<MoviePopularResponse> GetTrending(MovieRequest request)
        {
            string uri = $"trending/movie/{request.TrendingTime}?api_key={request.Api_key}";
            return ApiHelper.GetMovieApi<MoviePopularResponse>(uri, _httpClient);
        }

        public async Task<List<MovieDetailResponse>> GetListMovieDetailsByListMovieId(List<string> movieIds)
        {
            var result = new List<MovieDetailResponse>();
            if (movieIds.Count() > 0)
            {                
                foreach (var item in movieIds)
                {
                    MovieRequest request = new MovieRequest();
                    request.Api_key = _api_key;
                    request.Language = "en-US";
                    request.Movie_id = item;
                    var movieDetail = await GetMovieDetail(request);
                    result.Add(movieDetail);
                }
            }
            return result.OrderBy(x=>x.VoteAverage).ToList();
        }
        
    }
}
