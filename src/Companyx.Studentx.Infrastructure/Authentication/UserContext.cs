using Companyx.Companyx.Studentx.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Companyx.Companyx.Studentx.Infrastructure.Authentication
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserContext(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Guid UserId => _httpContext
            .HttpContext?.User
            .GetUserId() ?? throw new ApplicationException("User context is unavailable");

        public string Name => _httpContext?.HttpContext?.User?.Identity?.Name ?? string.Empty;

        public string? GetClaimsByValue(string claim) => _httpContext?.HttpContext?.User?.FindFirstValue(claim);

        public IEnumerable<Claim> GetClaimsIdentity() => _httpContext?.HttpContext?.User?.Claims ?? Enumerable.Empty<Claim>();

        public bool IsAuthenticated() =>_httpContext?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
