using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;

namespace Companyx.Companyx.Studentx.Core.Courses.DeleteCourses
{
    public sealed record DeleteCourseCommad(Guid Id) : ICommand<bool>;
}