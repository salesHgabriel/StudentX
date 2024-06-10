using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid UserId, Guid? SchooldId) : IDomainEvent;
}
