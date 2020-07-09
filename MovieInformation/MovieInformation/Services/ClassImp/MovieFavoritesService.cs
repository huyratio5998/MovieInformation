using MovieInformation.Data;
using MovieInformation.Models;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Services.ClassImp
{
    public class MovieFavoritesService : IMovieFavoritesService
    {
        private ApplicationDbContext _context;
        public MovieFavoritesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddMovieFavorites(string userName, string movieId)
        {
            try
            {                
                var movieFavorites = new MovieFavorites()
                {
                    userName = userName,
                    movieId=movieId,
                    isFavorites=true
                };
                _context.MovieFavorites.Add(movieFavorites);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool CheckMovieFavoritesByUsreId(string userName ,string movieId)
        {
            var check= _context.MovieFavorites.FirstOrDefault(x => x.userName.Equals(userName )&& x.movieId.Equals(movieId)&& x.isFavorites);
            return check != null ? true : false;
        }
        public bool DeleteMovieFavorites(string userName, string movieId)
        {
            try
            {
                var movieFavorites = _context.MovieFavorites.FirstOrDefault(x => x.userName == userName && x.movieId.Equals(movieId));                
                if (movieFavorites != null)
                {
                    movieFavorites.isFavorites = false;
                    _context.Entry(movieFavorites).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<string> GetMovieFavoritesIdByUserId(string userName)
        {
          
            try
            {
                var result = _context.MovieFavorites.Where(x => x.userName == userName && x.isFavorites == true)?
                    .Select(x => x.movieId).ToList();                    
                return result ?? new List<string>();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
