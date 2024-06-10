using Companyx.Companyx.Studentx.Application.Users.CreateUsers;
using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;

namespace Companyx.Companyx.Studentx.Application.Abstractions.Authentication
{
    public interface IAuthenticationService : IScopedService
    {
        Task<string> RegisterAsync(CreateUserRequest reques, CancellationToken cancellationToken = default);
    }
}
