using Companyx.Companyx.Studentx.Application.Users.GetAllStudents;
using Companyx.Companyx.Studentx.Domain.Courses;
using Companyx.Companyx.Studentx.Domain.Courses.Events;
using MediatR;

namespace Companyx.Companyx.Studentx.Core.Courses.CreateCourses
{
    public sealed class CreatedCourseDomainEventHandler : INotificationHandler<CreatedCourseDomainEvent>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IGetAllStudentsQuery _getAllStudentsQuery;
        public CreatedCourseDomainEventHandler(ICourseRepository courseRepository, IGetAllStudentsQuery getAllStudentsQuery)
        {
            _courseRepository = courseRepository;
            _getAllStudentsQuery = getAllStudentsQuery;
        }

        public async Task Handle(CreatedCourseDomainEvent notification, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(notification.CourseId, cancellationToken);

            var students = await _getAllStudentsQuery.FindAsync();

            foreach (var student in students)
            {
                //INFO: maybe send mail to all student about new course
            }
        }
    }
}
