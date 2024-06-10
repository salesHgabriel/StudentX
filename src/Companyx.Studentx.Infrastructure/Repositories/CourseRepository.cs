using Companyx.Companyx.Studentx.Domain.Courses;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;

namespace Companyx.Companyx.Studentx.Infrastructure.Repositories
{
    internal class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}