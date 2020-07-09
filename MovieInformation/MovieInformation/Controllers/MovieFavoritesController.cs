using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieInformation.Models;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;

namespace MovieInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieFavoritesController : ControllerBase
    {
        private IMovieFavoritesService _movieFavoritesService;
        private IMovieService _movieService;
        private readonly IConfiguration _config;
        private readonly string _api_key;

        public MovieFavoritesController(IMovieFavoritesService movieFavoritesService, IMovieService movieService, IConfiguration config)
        {
            _movieFavoritesService = movieFavoritesService;
            _movieService = movieService;
            _config = config;
            _api_key = _config.GetValue<string>("AppSettings:Api_Key");
        }

        public async Task<ActionResult<List<MovieDetailResponse>>> GetMovieFavorites(string userId)
        {            
            var result = new List<MovieDetailResponse>();
            var lstMovieIds = _movieFavoritesService.GetMovieFavoritesIdByUserId(userId);
            if (lstMovieIds == null) return NotFound();

            foreach (var item in lstMovieIds)
            {
                MovieRequest request = new MovieRequest();
                request.Api_key = _api_key;
                request.Language = "en-US";
                request.Movie_id = item;
                var movieDetail = await _movieService.GetMovieDetail(request);
                result.Add(movieDetail);
            }
            return result;
        }

        [HttpPost]
        public bool CreateMovieFavorites(string userId, string movieId)
        {            
            return _movieFavoritesService.AddMovieFavorites(userId,  movieId);            
        }

        [HttpPut]
        public bool UpdateRemoveMovieFavorites(string userId, string movieId)
        {            
            return _movieFavoritesService.DeleteMovieFavorites(userId, movieId);            
        }       
    }
}