using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;


namespace Companyx.Companyx.Studentx.Core.Courses.UpdateCourses
{
    public sealed record UpdateCourseCommand(Guid Id, string Name, string Description) : ICommand<bool>;
}
