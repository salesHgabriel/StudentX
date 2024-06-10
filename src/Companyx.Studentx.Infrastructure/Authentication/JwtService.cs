using Companyx.Companyx.Studentx.Application.Abstractions.Authentication;
using Companyx.Companyx.Studentx.Application.Users.LoginUsers;
using Companyx.Companyx.Studentx.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Companyx.Companyx.Studentx.Infrastructure.Authentication
{
    public class JwtService : IJwtService
    {
        private readonly UserManager<User> _userManager;

        private readonly JwtBearerSettings _jwtBearerOptions;

        public JwtService(UserManager<User> userManager, IOptions<JwtBearerSettings> options)
        {
            _userManager = userManager;
            _jwtBearerOptions = options.Value;
        }

        public async Task<TokenResponse> CreateTokenAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await GetClaimsUserAsync(user, claims);
            var encodedToken = WriteToken(identityClaims);

            return TokenReponse(encodedToken, user, claims);
        }

        private async Task<ClaimsIdentity> GetClaimsUserAsync(User user, ICollection<Claim> claims)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;
        }

        private string WriteToken(ClaimsIdentity identityClaims)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtBearerOptions.Secret);
            var token = tokenHandle.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _jwtBearerOptions.Issuer,
                Audience = _jwtBearerOptions.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_jwtBearerOptions.ExpirationInHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandle.WriteToken(token);
            return encodedToken;
        }

        private TokenResponse TokenReponse(string encodedToken, User user, ICollection<Claim> claims)
        {
            var filtro = new List<string>(){
                new string("sub"),
                new string("jti"),
                new string("nbf"),
                new string("iat"),
                new string("iss"),
                new string("aud"),
                new string("email"),
            };
            return new TokenResponse
            {
                AccessToken = encodedToken,
                ExpiratioIn = TimeSpan.FromHours(_jwtBearerOptions.ExpirationInHours).TotalSeconds,
                UserToken = new LoginUserResponse
                {
                    Email = user.Email,
                    UserId = user.Id.ToString(),
                    Claims = claims.Select(x => new ClaimsResponse { Type = x.Type, Value = x.Value }).Where(x => !filtro.Contains(x.Type)),
                    UserName = user.UserName
                }
            };
        }

        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}