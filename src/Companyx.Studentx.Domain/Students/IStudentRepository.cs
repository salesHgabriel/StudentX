using Companyx.Companyx.Studentx.Domain.Shared;
using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;

namespace Companyx.Companyx.Studentx.Domain.Students
{
    public interface IStudentRepository : IRepository<Student>, IScopedService
    {
        public Task<Student> AddUserOnSchoolAsync(Guid userId, Guid schoolId);
    }
}