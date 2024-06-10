using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;

namespace Companyx.Companyx.Studentx.Core.Students.DeleteUser
{
    public sealed record DeleteUserCommand(Guid Id) : ICommand<bool>; 
}
