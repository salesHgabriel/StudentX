using Companyx.Companyx.Studentx.Core.Courses.UpdateCourses;
using FluentValidation;

namespace Companyx.Companyx.Studentx.Core.Courses.CreateCourses
{
    public  class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Id).NotNull();
        }
    }
}
