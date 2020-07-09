using MovieInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Services.Interfaces
{
    public interface IMovieFavoritesService
    {
        bool AddMovieFavorites(string userId, string movieId);
        bool DeleteMovieFavorites(string userId, string movieId);
        List<string> GetMovieFavoritesIdByUserId(string userId);
        bool CheckMovieFavoritesByUsreId(string userId, string movieId);

    }
}
