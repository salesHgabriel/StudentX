using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Students;
using Companyx.Companyx.Studentx.Domain.Users.Events;
using MediatR;

namespace Companyx.Companyx.Studentx.Core.Students.CreateUser
{
    public sealed class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepository _repository;

        public UserCreatedDomainEventHandler(IUnitOfWork unitOfWork, IStudentRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _repository.AddUserOnSchoolAsync(notification.UserId, notification.SchooldId!.Value);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}