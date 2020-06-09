using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IConfiguration _config;

        private readonly string _api_key;
        // GET: Movies
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context, IMovieService movieService, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            this.movieService = movieService;
            _config = config;
            _api_key = _config.GetValue<string>("AppSettings:Api_Key");
        }      

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
        public async Task<IActionResult> Index()
        {
            ViewBag.lstPopular = await GetPopularMovies();
            ViewBag.lstTopRating = await GetTopRateMovies();

            return View(await _context.Movies.ToListAsync());
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
