using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Courses;


namespace Companyx.Companyx.Studentx.Core.Courses.CreateCourses
{
    public sealed class CreateCourseCommandHandler : ICommandHandler<CreateCourseCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;

        public CreateCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            _courseRepository.Add(Course.Create(request.Name, request.Decription));

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
