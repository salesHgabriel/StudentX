using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Shared;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Companyx.Companyx.Studentx.Infrastructure.Repositories
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityRoot , new()
    {
        protected readonly AppDbContext DbContext;

        protected Repository(AppDbContext dbContext) => DbContext = dbContext;

        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<TEntity>()
                .FirstOrDefaultAsync(user => user.Id.Equals(id), cancellationToken);
        }

        public virtual void Add(TEntity entity) => DbContext.Add(entity);

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
           await  DbContext.AddAsync(entity, cancellationToken);
        }

        public virtual void Remove(TEntity entity) 
        {
            entity.Remove();
            DbContext.Update(entity);
        }

        /// <summary>
        /// IMPORTANT: this method remove database !!
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity) => DbContext.Remove(entity);

        public virtual IQueryable<TEntity?> Query(Expression<Func<TEntity, bool>> expression) => DbContext.Set<TEntity>().Where(expression);

  
        public void Dispose()
        {
            DbContext.Dispose();
        }

      
    }
}
