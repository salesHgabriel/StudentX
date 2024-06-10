using FluentValidation;

namespace Companyx.Companyx.Studentx.Core.Students.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(c => c.UsernName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
        }
    }
}
