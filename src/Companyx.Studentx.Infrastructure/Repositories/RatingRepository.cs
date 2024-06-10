using Companyx.Companyx.Studentx.Domain.Ratings;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;

namespace Companyx.Companyx.Studentx.Infrastructure.Repositories
{
    internal class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}