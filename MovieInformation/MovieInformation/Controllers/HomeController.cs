﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieInformation.Data;
using MovieInformation.Models;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;

namespace MovieInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private IMovieService movieService;
        private IGenreService genreService;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPaymentService _paymentService;
        private readonly string _api_key;
        private UserManager<MovieInformationUser> _userManager;
        private readonly IMovieFavoritesService _movieFavoritesService;
        // GET: Movies
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context,
            IMovieService movieService, IConfiguration config, IGenreService genreService,
            IHttpContextAccessor httpContextAccessor, IPaymentService paymentService,
            UserManager<MovieInformationUser> userManager, IMovieFavoritesService movieFavoritesService
            )
        {
            _logger = logger;
            _context = context;
            this.movieService = movieService;
            this.genreService = genreService;
            _config = config;
            _api_key = _config.GetValue<string>("AppSettings:Api_Key");
            _httpContextAccessor = httpContextAccessor;
            _paymentService = paymentService;
            _userManager = userManager;
            _movieFavoritesService = movieFavoritesService;
        }
        #region movie Api 
        
        public async Task<MoviePopularResponse> GetPopularMovies(int page = 1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Region = "US";
            request.Page = page;
            var lstMoviePopular = await movieService.GetPopularMovies(request);
            return lstMoviePopular;
        }
        public async Task<MoviePopularResponse> GetTopRateMovies(int page = 1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Page = page;
            var lstMovieTopRate = await movieService.GetTopRateMovies(request);
            return lstMovieTopRate;
        }
        public async Task<MoviePopularResponse> GetNowPlayingMovies(int page = 1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Page = page;
            var lstNowPlaying = await movieService.GetNowPlayingMovies(request);
            return lstNowPlaying;
            
          
        }
        public async Task<MoviePopularResponse> GetUpcomingMovies(int page = 1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Page = page;
            var lstUpcoming = await movieService.GetUpcomingMovies(request);
            return lstUpcoming;
        }
        public async Task<MoviePopularResponse> GetDayTrendingMovies(int page = 1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;            
            request.Page = page;
            request.TrendingTime = "day";
            var lstTrending = await movieService.GetTrending(request);
            return lstTrending;
        }
        public async Task<MoviePopularResponse> GetWeekTrendingMovies(int page = 1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Page = page;
            request.TrendingTime = "week";
            var lstTrending = await movieService.GetTrending(request);
            return lstTrending;
        }
        public async Task<GenreResponse> GetlstGenres()
        {
            SearchRequest request = new SearchRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            var lstGenres = await genreService.GetListGenre(request);
            return lstGenres;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var lstNowPlayingMovies = await GetNowPlayingMovies();
            bool isVipUser = false;
            if (user != null)
            {
                isVipUser = _paymentService.CheckUserVipAccount(user.Id);
                // favorites
                var isFavoriteMovie = false;
                int count = 0;
                foreach (var check in lstNowPlayingMovies.Results)
                {
                    isFavoriteMovie = _movieFavoritesService.CheckMovieFavoritesByUsreId(user.Id, check.Id.ToString());
                    if (isFavoriteMovie) lstNowPlayingMovies.Results[count].isMovieFavorites = true;
                    count++;
                }
            };
            ViewBag.IsUserVip = isVipUser;
            ViewBag.CurrentLoginId = user == null ? "" : user.Id;
            if (isVipUser)
            {
                ViewBag.lstUpComing = await GetUpcomingMovies();
                ViewBag.lstTopRating = await GetTopRateMovies();
                ViewBag.lstWeekTrending = await GetWeekTrendingMovies();
            }
            ViewBag.lstGenres = await GetlstGenres();
            
                    
            ViewBag.lstNowPlaying = lstNowPlayingMovies;
            ViewBag.lstPopular = await GetPopularMovies();
            ViewBag.lstDayTrending = await GetDayTrendingMovies();

            return View(await _context.Movies.ToListAsync());
        }
        public ActionResult PaySuccess()
        {
            return View("PaySuccess");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        [HttpGet(nameof(ExternalLoginCallback))]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            //Here we can retrieve the claims
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return null;
        }
    }
}
