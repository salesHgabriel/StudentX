using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Students;
using Companyx.Companyx.Studentx.Domain.Users.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Companyx.Companyx.Studentx.Core.Students.DeleteUser
{
    public sealed class UserRemovedDomainEventHandler : INotificationHandler<UserRemovedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _repository;

        public UserRemovedDomainEventHandler(IUnitOfWork unitOfWork, IStudentRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Handle(UserRemovedDomainEvent notification, CancellationToken cancellationToken)
        {
            var student = await _repository
                .Query(s => s.UserId == notification.UserId && s.SchoolId == notification.SchooldId)
                .SingleAsync();

            _repository.Delete(student);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}