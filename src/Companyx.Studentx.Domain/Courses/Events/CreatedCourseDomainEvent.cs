

using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Courses.Events
{
    public sealed record CreatedCourseDomainEvent(Guid CourseId) : IDomainEvent;
}
