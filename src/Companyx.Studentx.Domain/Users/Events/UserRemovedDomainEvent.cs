using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Users.Events
{
    public sealed record UserRemovedDomainEvent(Guid UserId, Guid? SchooldId) : IDomainEvent;
}