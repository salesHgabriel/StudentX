using Companyx.Companyx.Studentx.Domain.Abstraction;
using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;
using System.Linq.Expressions;


namespace Companyx.Companyx.Studentx.Domain.Shared
{
    public interface IRepository<TEntity> : IScopedService, IDisposable where TEntity : EntityRoot
    {
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        void Delete(TEntity entity);

        IQueryable<TEntity?> Query(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
