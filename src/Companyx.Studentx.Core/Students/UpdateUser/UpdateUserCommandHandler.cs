using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Companyx.Companyx.Studentx.Core.Students.UpdateUser
{
    public sealed class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand, Guid>
    {
        private readonly UserManager<User> _userManager;

        public UpdateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<Guid>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());

            if (user is null)
            {
                return Result.Failure<Guid>(UserErros.NotFound);
            }

            user.SetName(request.Name);

            await _userManager.UpdateAsync(user);

            return user.Id;
        }
    }
}