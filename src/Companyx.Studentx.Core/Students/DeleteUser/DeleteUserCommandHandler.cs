using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Students;
using Companyx.Companyx.Studentx.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Companyx.Companyx.Studentx.Core.Students.DeleteUser
{
    public sealed class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly IStudentRepository _repository;

        public DeleteUserCommandHandler(UserManager<User> userManager, IStudentRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<Result<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user is null)
            {
                return Result.Failure<bool>(UserErros.NotFound);
            }

            var student = await _repository
            .Query(s => s.UserId == request.Id)
            .SingleOrDefaultAsync();

            if (student is null)
            {
                return Result.Failure<bool>(StudentErros.NotFound);
            }

            user.RemoveStudent(student.UserId, student.SchoolId);
            
            var result = await _userManager.UpdateAsync(user);


            return result.Succeeded;
        }
    }
}