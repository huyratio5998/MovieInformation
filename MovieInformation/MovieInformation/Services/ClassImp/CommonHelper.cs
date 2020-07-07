using Microsoft.AspNetCore.Http;
using MovieInformation.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieInformation.Services.ClassImp
{
    public class CommonHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommonHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public UserViewModel GetCurrentUser()
        {
            var currentUser = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            return new UserViewModel();
        }
    }
}
