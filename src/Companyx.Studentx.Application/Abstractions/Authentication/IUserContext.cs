using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;
using System.Security.Claims;

namespace Companyx.Companyx.Studentx.Application.Abstractions.Authentication
{
    public interface IUserContext : IScopedService
    {
        Guid UserId { get; }
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
        string? GetClaimsByValue(string claim);
    }
}