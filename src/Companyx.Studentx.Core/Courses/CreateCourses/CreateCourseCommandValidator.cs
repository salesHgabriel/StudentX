using FluentValidation;

namespace Companyx.Companyx.Studentx.Core.Courses.CreateCourses
{
    public  class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Decription).NotEmpty();
        }
    }
}
