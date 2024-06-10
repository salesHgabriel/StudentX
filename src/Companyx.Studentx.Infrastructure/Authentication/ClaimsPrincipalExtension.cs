using System.Security.Claims;

namespace Companyx.Companyx.Studentx.Infrastructure.Authentication
{
    public static class ClaimsPrincipalExtension
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            string userId = principal?.FindFirstValue(ClaimTypes.NameIdentifier);

            return Guid.TryParse(userId, out var parsedUserId)
                ? parsedUserId :
                throw new ApplicationException("User identifier is unavailable");
        }

        public static string GetIdentityId(this ClaimsPrincipal principal)
        {
            return principal?.FindFirstValue(ClaimTypes.NameIdentifier) ??
                   throw new ApplicationException("User identity is unavailable");
        }
    }
}
