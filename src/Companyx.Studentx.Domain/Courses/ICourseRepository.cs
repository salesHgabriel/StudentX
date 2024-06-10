using Companyx.Companyx.Studentx.Domain.Ratings;
using Companyx.Companyx.Studentx.Domain.Shared;
using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;

namespace Companyx.Companyx.Studentx.Domain.Courses
{
    public interface ICourseRepository : IRepository<Course>, IScopedService
    {
        void Add(Course course);
    }
}
