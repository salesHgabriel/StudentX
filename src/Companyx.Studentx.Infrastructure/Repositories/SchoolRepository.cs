using Companyx.Companyx.Studentx.Domain.Schools;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Companyx.Companyx.Studentx.Infrastructure.Repositories
{
    internal class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<School> GeHeadSchoolAsync() => DbContext.Schools.FirstAsync(s => s.Name.Equals("school admin")) ?? throw new ArgumentNullException("Head school not found");

        public async Task<School> GetSchoolOrHeadAsync(Guid? id)
        {
            if (id.HasValue)
            {
                var school = await DbContext.Schools.FirstOrDefaultAsync(s => s.Id.Equals(id)) ?? await GeHeadSchoolAsync();
            }

            return await GeHeadSchoolAsync();
        }
    }
}