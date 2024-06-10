using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Schools;
using Companyx.Companyx.Studentx.Domain.Users;
using Companyx.Companyx.Studentx.Domain.Users.Events;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Companyx.Companyx.Studentx.Core.Students.CreateUser
{
    public sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
     
        private readonly UserManager<User> _userManager;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(UserManager<User> userManager, ISchoolRepository schoolRepository, IMediator mediator)
        {

            _userManager = userManager;
            _schoolRepository = schoolRepository;
            _mediator = mediator;
        }

        public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var schoolId = (await _schoolRepository.GetSchoolOrHeadAsync(request.SchoolId)).Id;

            var existingMail = (await _userManager.FindByEmailAsync(request.Email!)) != null;

            if (existingMail)
            {
                return Result.Failure<Guid>(UserErros.MailExisting);
            }

            var user = User.Create(request.UsernName, request.Email, schoolId).Value;

            var result = await _userManager.CreateAsync(user, request.PassWord);
            if (!result.Succeeded)
            {
                var error = result.Errors.Select(err => new Error(err.Code, err.Description)).LastOrDefault();
                return Result.Failure<Guid>(error);
            }

            User.AssociateAsStudent(user.Id, schoolId);

            return user.Id;

        }
    }
}