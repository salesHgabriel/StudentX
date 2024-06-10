using Companyx.Companyx.Studentx.Application.Users.LoginUsers;
using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;

namespace Companyx.Companyx.Studentx.Application.Abstractions.Authentication
{
    public interface IJwtService : IScopedService
    {
        Task<TokenResponse> CreateTokenAsync(string email);
    }
}