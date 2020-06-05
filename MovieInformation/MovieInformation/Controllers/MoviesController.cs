using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private IMovieService movieService;
        private readonly IConfiguration _config;

        private readonly string _api_key;
        // GET: Movies
        public MoviesController(ApplicationDbContext context, IMovieService movieService, IConfiguration config)
        {
            _context = context;
            this.movieService = movieService;
            _config = config;
            _api_key= _config.GetValue<string>("AppSettings:Api_Key");
        }

        public async Task<bool> SaveMovieInfor()
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Movie_id = "419704";

            MovieDetailResponse movieDetail = await movieService.GetMovieDetail(request);
            return true;
        }
        //
        
        public  bool RatingMovieInformation()
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Movie_id = "1444";
            request.Guest_session_id = "98fce7280d3315c15406f10e29b17c58";
            var raintMovie =  movieService.RatingMovies(request,8.0);
            return true;
        }
        public async Task<MoviePopularResponse> GetPopularMovies(int page=1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Region = "US";
            request.Page= page;
            var lstMoviePopular = await movieService.GetPopularMovies(request);
            return lstMoviePopular;
        }
        public async Task<MoviePopularResponse> GetTopRateMovies(int page = 1)
        {
            MovieRequest request = new MovieRequest();
            request.Api_key = _api_key;
            request.Language = "en-US";
            request.Page = page;
            var lstMovieTopRate= await movieService.GetTopRateMovies(request);
            return lstMovieTopRate;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.lstPopular = await GetPopularMovies();
            ViewBag.lstTopRating= await GetTopRateMovies();
            
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,displayName,imageUrl,author,times,userScore,trailerUrl,descriptions,dateRelease,modifiedDate,CreatedDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.id = Guid.NewGuid();
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name,displayName,imageUrl,author,times,userScore,trailerUrl,descriptions,dateRelease,modifiedDate,CreatedDate")] Movie movie)
        {
            if (id != movie.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
            return _context.Movies.Any(e => e.id == id);
        }
    }
}
