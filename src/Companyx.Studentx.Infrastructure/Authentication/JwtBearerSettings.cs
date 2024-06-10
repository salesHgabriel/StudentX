
namespace Companyx.Companyx.Studentx.Infrastructure.Authentication
{
    public class JwtBearerSettings
    {
        public string Secret { get; set; } 
        public int ExpirationInHours { get; set; } 
        public string Issuer { get; set; } 
        public string Audience { get; set; } 
    }
}
