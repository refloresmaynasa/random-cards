using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Identity.Services
{
    public class SessionService : ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string CurrentUserId => _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type.Equals("uid"))?.Value;

        public string CurrentUserName => _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier))?.Value;

        public string CurrentUserEmail => _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email))?.Value;
    }
}
