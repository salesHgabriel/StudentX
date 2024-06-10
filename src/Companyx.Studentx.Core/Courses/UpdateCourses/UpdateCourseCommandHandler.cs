using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Courses;

namespace Companyx.Companyx.Studentx.Core.Courses.UpdateCourses
{
    public sealed class UpdateCourseCommandHandler : ICommandHandler<UpdateCourseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _repository;

        public UpdateCourseCommandHandler(ICourseRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (course is null)
            {
                return Result.Failure<bool>(CourseErros.NotFound);
            }

            course.SetName(request.Name);
            course.SetDescription(request.Description);
            course.SetUpdateAt();

            return await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        }
    }
}