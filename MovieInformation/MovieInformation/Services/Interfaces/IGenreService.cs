using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Services.Interfaces
{
    public interface IGenreService
    {
        Task<GenreResponse> GetListGenre(SearchRequest request);        
    }
}
