using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Schools
{
    public sealed record CreatedSchoolDomainEvent(Guid SchoolId) : IDomainEvent;
   
}