using Companyx.Companyx.Studentx.Application.Abstractions.Authentication;
using Companyx.Companyx.Studentx.Application.Users.LoginUsers;
using Companyx.Companyx.Studentx.Domain.Users;
using Companyx.Companyx.Studentx.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Companyx.Studentx.API.Controllers.Users
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/users")]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtService _jwtService;

        public UsersController(SignInManager<User> signInManager, IJwtService jwtService)
        {
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.PassWord, false, false);
            if (result.Succeeded)
                return Ok(await _jwtService.CreateTokenAsync(request.UserName));

            return BadRequest();
        }
    }
}