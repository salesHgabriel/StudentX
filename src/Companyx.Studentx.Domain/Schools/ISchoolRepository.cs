using Companyx.Companyx.Studentx.Domain.Shared;
using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;

namespace Companyx.Companyx.Studentx.Domain.Schools
{
    public interface ISchoolRepository : IRepository<School>, IScopedService
    {
        public Task<School> GeHeadSchoolAsync();
        Task<School> GetSchoolOrHeadAsync(Guid? id);
    }
}
