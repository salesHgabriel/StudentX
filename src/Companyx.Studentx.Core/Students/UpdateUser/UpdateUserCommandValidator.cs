using Companyx.Companyx.Studentx.Core.Courses.UpdateCourses;
using FluentValidation;

namespace Companyx.Companyx.Studentx.Core.Students.CreateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(c => c.Id).NotNull();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
