using Companyx.Companyx.Studentx.Domain.Shared;
using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;

namespace Companyx.Companyx.Studentx.Domain.Ratings
{
    public interface IRatingRepository : IRepository<Rating>, IScopedService
    {
    }
}
