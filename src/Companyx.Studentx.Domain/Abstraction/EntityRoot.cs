namespace Companyx.Companyx.Studentx.Domain.Abstraction
{
    public abstract class EntityRoot : IEntity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        protected EntityRoot()
        {
            Id = Guid.NewGuid();
            CreatedAtUTC = DateTime.UtcNow;
            UpdatedAtUTC = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedAtUTC { get; private set; }
        public DateTime UpdatedAtUTC { get; private set; }
       
        public DateTime? RemovedAtUTC { get; private set; }

        public void Remove() => RemovedAtUTC = DateTime.UtcNow;
        public void SetUpdateAt() => UpdatedAtUTC = DateTime.UtcNow;

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

    }
}
