using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using MovieInformation.Models;
using MovieInformation.Models.ViewModels;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;
using Newtonsoft.Json;

namespace MovieInformation.Controllers
{
    [Route("api/[controller]")]
    public class MovieFavoritesController : Controller
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
            if (lstMovieIds == null) return result;

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

        [HttpPost("AddFavorites")]        
        public IActionResult CreateMovieFavorites(string moviesFavorites)
        {
            try
            {
                MovieFavoriteModel favorites = JsonConvert.DeserializeObject<MovieFavoriteModel>(moviesFavorites);
                return Ok(_movieFavoritesService.AddMovieFavorites(favorites.userId, favorites.movieId));
            }catch(Exception e)
            {
                return BadRequest();                
            }
            
        }

        [HttpPut("RemoveFavorites")]        
        public IActionResult UpdateRemoveMovieFavorites(string moviesFavorites)
        {
            try
            {
                MovieFavoriteModel favorites = JsonConvert.DeserializeObject<MovieFavoriteModel>(moviesFavorites);
                return Ok(_movieFavoritesService.DeleteMovieFavorites(favorites.userId, favorites.movieId));
            }
            catch(Exception e)
            {
                return BadRequest();
                //throw e;
            }
   
        }       
    }
}