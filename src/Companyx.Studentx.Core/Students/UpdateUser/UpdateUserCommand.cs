using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;

namespace Companyx.Companyx.Studentx.Core.Students.UpdateUser
{
    public sealed record UpdateUserCommand(Guid Id, string Name) : ICommand<Guid>;
}
