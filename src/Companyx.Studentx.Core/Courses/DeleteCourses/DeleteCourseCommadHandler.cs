using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Courses;

namespace Companyx.Companyx.Studentx.Core.Courses.DeleteCourses
{
    public sealed class DeleteCourseCommadHandler : ICommandHandler<DeleteCourseCommad, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _repository;

        public DeleteCourseCommadHandler(IUnitOfWork unitOfWork, ICourseRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Result<bool>> Handle(DeleteCourseCommad request, CancellationToken cancellationToken)
        {
            var course = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (course is null)
            {
                return Result.Failure<bool>(new Error("Course.NotFound", "The Course not found"));
            }

            course.Remove();

            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
