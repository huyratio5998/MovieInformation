using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieInformation.Data;
using MovieInformation.Models;
using MovieInformation.Services.ApiModels;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;

namespace MovieInformation.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IMovieService _movieService;
        private readonly IConfiguration _config;
        private readonly string _api_key;
        private UserManager<MovieInformationUser> _userManager;
        private readonly IPaymentService _paymentService;
        private readonly IMovieFavoritesService _movieFavoritesService;

        private readonly Random _random = new Random();
        // GET: Movies
        public MoviesController(ApplicationDbContext context, IMovieService movieService, IConfiguration config,
               UserManager<MovieInformationUser> userManager,  IPaymentService paymentService,
               IMovieFavoritesService movieFavoritesService

            )
        {
            _context = context;
            _movieService = movieService;
            _config = config;
            _api_key= _config.GetValue<string>("AppSettings:Api_Key");
            _userManager = userManager;
            _paymentService = paymentService;
            _movieFavoritesService = movieFavoritesService;
        }
        public async Task<MoviePopularResponse> GetPopularMovies(int page = 1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Region = "US";
            request.Page = page;
            var lstMoviePopular = await _movieService.GetPopularMovies(request);
            return lstMoviePopular;
        }      
        public async Task<IActionResult> FavoriteMovies()
        {
            var user = await _userManager.GetUserAsync(User);
            bool isVipUser = false;
            if (user != null)
            {
                isVipUser = _paymentService.CheckUserVipAccount(user.Id);
            };
            ViewBag.IsUserVip = isVipUser;
            //            
            if (isVipUser)
            {
                var result = new List<MovieDetailResponse>();
                var lstMovieIds = _movieFavoritesService.GetMovieFavoritesIdByUserId(user.Id);
                if (lstMovieIds == null) return View(result);              
                foreach (var item in lstMovieIds)
                {
                    MovieRequest request = new MovieRequest();
                    request.Api_key = _api_key;
                    request.Language = "en-US";
                    request.Movie_id = item;
                    var movie = await _movieService.GetMovieDetail(request);
                    if (movie != null) result.Add(movie);
                }
                return View(result);
            }
            
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Detail(string movieId)
        {
            var user = await _userManager.GetUserAsync(User);
            bool isVipUser = false;
            bool isFavoriteMovie = false;
            if (user != null)
            {
                isVipUser = _paymentService.CheckUserVipAccount(user.Id);
                isFavoriteMovie= _movieFavoritesService.CheckMovieFavoritesByUsreId(user.Id, movieId);
            };
            ViewBag.CurrentLoginId = user == null ? "" : user.Id;
            ViewBag.IsUserVip = isVipUser;
            ViewBag.IsFavorite = isFavoriteMovie;
            //ViewBag.CurrentUserName = user.UserName;
            //ViewBag.GuestSession = user.Guest_session_id;
            #region request Model
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Movie_id = movieId;
            //
            MovieRequest requestCast = new MovieRequest();
            requestCast.Api_key = _api_key;
            requestCast.Movie_id = movieId;
            //
            MovieRequest requestKeyword = new MovieRequest();
            requestKeyword.Api_key = _api_key;
            requestKeyword.Movie_id = movieId;
            //
            MovieRequest requestVideo = new MovieRequest();
            requestVideo.Api_key = _api_key;
            requestVideo.Movie_id = movieId;
            requestVideo.Language = "en-US";
            //
            MovieRequest requestImage = new MovieRequest();
            requestImage.Api_key = _api_key;
            requestImage.Movie_id = movieId;
            //
            MovieRequest requestRecommendations= new MovieRequest();
            requestRecommendations.Api_key = _api_key;
            requestRecommendations.Movie_id = movieId;
            #endregion

            var lstKeywordMovies = await _movieService.GetKeywordMovies(requestKeyword);
            var lstVideoMovies = await _movieService.GetVideosMovies(requestVideo);
            var lstImageMovies = await _movieService.GetImagesMovies(requestImage);
            //
            int num = _random.Next(10);
            var lstMoviesRandom = await GetPopularMovies(num);
            //var lstRecommendations = await movieService.GetRecommendationsMovies(requestRecommendations);
            var movieDetail = _movieService.GetMovieDetail(request);    
            
            MovieCreditsResponse lstCredits= await _movieService.GetCreditsMovies(requestCast);
            ViewBag.Credits = lstCredits;
            ViewBag.Director = lstCredits.Crew.FirstOrDefault(x => x.Job.Equals("Director"));
            ViewBag.Writer = lstCredits.Crew.Where(x => x.Job.Equals("Screenplay")).ToList();
            ViewBag.Editting = lstCredits.Crew.Where(x => x.Department.Equals("Editing")).ToList();
            ViewBag.Keywords = lstKeywordMovies;
            ViewBag.Videos = lstVideoMovies.Results.Take(8).ToList();
            ViewBag.Backdrops = lstImageMovies.Backdrops.Take(14).ToList();
            ViewBag.Posters = lstImageMovies.Posters.Take(7).ToList();
            ViewBag.RecommendationMovies = lstMoviesRandom.Results.Take(5).ToList();
            //ViewBag.RecommendationMovies = lstRecommendations.Results.Take(5).ToList();
            return View("Detail", await movieDetail);
        }
        //
        
        //public bool RatingMovieInformation(string movieId,string guestSessionId)
        //{
        //    MovieRequest request = new MovieRequest();
        //    request.Api_key = _api_key;
        //    request.Movie_id = "1444";
        //    request.Guest_session_id = "98fce7280d3315c15406f10e29b17c58";
        //    var raintMovie =  movieService.RatingMovies(request,8.0);
        //    return true;
        //}     
        public async Task<IActionResult> Index(int page=1,string option="")
        {
            var user = await _userManager.GetUserAsync(User);
            bool isVipUser = false;
            if (user != null)
            {
                isVipUser = _paymentService.CheckUserVipAccount(user.Id);
            };
            ViewBag.IsUserVip = isVipUser;
            var lstMovies = await GetPopularMovies(page);            
            switch (option)
            {
                case "popularityDes": 
                    lstMovies.Results= lstMovies.Results.OrderByDescending(x => x.Popularity).ToArray();
                    break;
                case "popularityAsc":
                    lstMovies.Results = lstMovies.Results.OrderBy(x => x.Popularity).ToArray()  ;
                    break;
                case "ratingDes":
                    lstMovies.Results = lstMovies.Results.OrderByDescending(x => x.VoteAverage).ToArray();
                    break;
                case "ratingAsc":
                    lstMovies.Results = lstMovies.Results.OrderBy(x => x.VoteAverage).ToArray();
                    break;
                case "releaseAsc":
                    lstMovies.Results = lstMovies.Results.OrderBy(x => x.ReleaseDate).ToArray();
                    break;
                case "releaseDes":
                    lstMovies.Results =  lstMovies.Results.OrderByDescending(x => x.ReleaseDate).ToArray();
                    break;                
            }            
            return View(lstMovies);
        }
    

       
    }
}
