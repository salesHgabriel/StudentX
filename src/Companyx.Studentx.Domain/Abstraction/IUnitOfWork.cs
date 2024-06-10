namespace Companyx.Companyx.Studentx.Domain.Abstraction
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}