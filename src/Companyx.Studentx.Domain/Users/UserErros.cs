using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Users
{
    public static class UserErros
    {
        public static readonly Error NotFound = new(
     "User.NotFound",
     "The user the specified identifier was not found");

        public static readonly Error MailExisting = new(
        "User.MailExisting",
        "Mail is create our system");
    }
}