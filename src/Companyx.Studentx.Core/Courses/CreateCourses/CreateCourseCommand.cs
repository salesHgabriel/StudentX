using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;

namespace Companyx.Companyx.Studentx.Core.Courses.CreateCourses
{
    public sealed record CreateCourseCommand(string Name, string Decription) : ICommand<bool>;
}
