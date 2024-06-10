using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Students.Events
{
    public sealed record AssocietatedUserWithSchoolDomainEvent(Guid UserId, Guid SchoolId) : IDomainEvent; 
}
