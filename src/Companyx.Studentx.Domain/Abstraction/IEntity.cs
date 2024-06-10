namespace Companyx.Companyx.Studentx.Domain.Abstraction
{
    public interface IEntity
    {
        IReadOnlyList<IDomainEvent> GetDomainEvents();

        void ClearDomainEvents();
    }
}
