namespace Companyx.Companyx.Studentx.Application.Users.LoginUsers
{
    public class LoginUserResponse
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IEnumerable<ClaimsResponse> Claims { get; set; }
    }

    public class ClaimsResponse
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public double ExpiratioIn { get; set; }
        public LoginUserResponse UserToken { get; set; }
    }
}