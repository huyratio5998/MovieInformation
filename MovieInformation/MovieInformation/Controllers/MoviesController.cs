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
        private readonly IUserSessionService _userSessionService;

        private readonly Random _random = new Random();
        // GET: Movies
        public MoviesController(ApplicationDbContext context, IMovieService movieService, IConfiguration config,
               UserManager<MovieInformationUser> userManager,  IPaymentService paymentService,
               IMovieFavoritesService movieFavoritesService, IUserSessionService userSessionService

            )
        {
            _context = context;
            _movieService = movieService;
            _config = config;
            _api_key= _config.GetValue<string>("AppSettings:Api_Key");
            _userManager = userManager;
            _paymentService = paymentService;
            _movieFavoritesService = movieFavoritesService;
            _userSessionService = userSessionService;
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
                result = await _movieService.GetListMovieDetailsByListMovieId(lstMovieIds);
                return View(result);
            }
            
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Detail(string movieId)
        {
            var user = await _userManager.GetUserAsync(User);
            bool isVipUser = false;
            bool isFavoriteMovie = false;            
            double userRaiting = 0;
            if (user != null)
            {
                isVipUser = _paymentService.CheckUserVipAccount(user.Id);
                isFavoriteMovie= _movieFavoritesService.CheckMovieFavoritesByUsreId(user.Id, movieId);
                //get lst RatedMovie
                RatedMoviesResponse raitedMovie = new RatedMoviesResponse();               
                    MovieRequest ratedRequest = new MovieRequest();
                ratedRequest.Api_key = _api_key;
                ratedRequest.Guest_session_id = user.Guest_session_id;
                    raitedMovie = await _userSessionService.GetRatedMovie(ratedRequest, "created_at.desc");
                if (raitedMovie.Results.Count() > 0)
                {
                    var movie = raitedMovie.Results.FirstOrDefault(x => x.Id.Equals(movieId));
                    if(movie!=null) userRaiting = movie.Rating;
                }                
            };
            ViewBag.CurrentLoginId = user == null ? "" : user.Id;
            ViewBag.IsUserVip = isVipUser;
            ViewBag.IsFavorite = isFavoriteMovie;            
           // ViewBag.GuestSession = user.Guest_session_id;
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
            int num = _random.Next(100);
            var lstMoviesRandom = await GetPopularMovies(num);
            //var lstRecommendations = await movieService.GetRecommendationsMovies(requestRecommendations);
            var movieDetail =await _movieService.GetMovieDetail(request);    
            
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
            //check rated movie
            ViewBag.UserRating = userRaiting;


            return View("Detail", movieDetail);
        }
        //

        public async Task<bool> RatingMovieInformation(string movieId, double ratting)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {                
                MovieRequest request = new MovieRequest();
                request.Api_key = _api_key;
                request.Movie_id = movieId;
                request.Guest_session_id = user.Guest_session_id;
                var raitMovie = await _movieService.RatingMovies(request, ratting);
                if (raitMovie.Status_code == 1|| raitMovie.Status_code==12) return true;
                return false;                
            }
            return false;
        }
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
    
        public async Task<IActionResult> RatedMovies(int page = 1, string option = "")
        {
            var user = await _userManager.GetUserAsync(User);
            bool isVipUser = false;
            if (user != null)
            {
                isVipUser = _paymentService.CheckUserVipAccount(user.Id);
            };
            ViewBag.IsUserVip = isVipUser;
            RatedMoviesResponse rateMovie = new RatedMoviesResponse();
            if (user != null)
            {
                MovieRequest request = new MovieRequest();
                request.Api_key = _api_key;                
                request.Guest_session_id = user.Guest_session_id;
                rateMovie = await _userSessionService.GetRatedMovie(request, "created_at.desc");                                
            }
            switch (option)
            {
                case "popularityDes":
                    rateMovie.Results = rateMovie.Results.OrderByDescending(x => x.Popularity).ToArray();
                    break;
                case "popularityAsc":
                    rateMovie.Results = rateMovie.Results.OrderBy(x => x.Popularity).ToArray();
                    break;
                case "ratingDes":
                    rateMovie.Results = rateMovie.Results.OrderByDescending(x => x.VoteAverage).ToArray();
                    break;
                case "ratingAsc":
                    rateMovie.Results = rateMovie.Results.OrderBy(x => x.VoteAverage).ToArray();
                    break;
                case "releaseAsc":
                    rateMovie.Results = rateMovie.Results.OrderBy(x => x.ReleaseDate).ToArray();
                    break;
                case "releaseDes":
                    rateMovie.Results = rateMovie.Results.OrderByDescending(x => x.ReleaseDate).ToArray();
                    break;
            }
            return View(rateMovie);
        }
       
    }
}
