using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;

namespace Companyx.Companyx.Studentx.Core.Students.CreateUser
{
    public sealed record CreateUserCommand(string UsernName, string Email, string PassWord, Guid? SchoolId) :  ICommand<Guid>;
}