using Companyx.Companyx.Studentx.Application.Abstractions.Authentication;
using Companyx.Companyx.Studentx.Application.Ratings.GetAllRatings;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using ShortCleanLinqExtensions.src.Extensions;
using ShortCleanLinqExtensions.src.Utils.PaginatorHelper;

namespace Companyx.Companyx.Studentx.Infrastructure.Queries.Ratings
{
    public class GetAllRatingsQuery : IGetAllRatingsQuery
    {
        private readonly AppDbContext _db;
        private readonly IUserContext _userContext;
        public GetAllRatingsQuery(AppDbContext db, IUserContext userContext)
        {
            _db = db;
            _userContext = userContext;
        }

        public Task<PagedResponse<GetAllRatingsResponse>> FindAsync(int page = 1, int limit = 1)
            => _db.Ratings
                .Where(r => r.UserId == _userContext.UserId)
                .Select(r => new GetAllRatingsResponse(r.Start, r.Comment, r.CreatedAtUTC))
                .PaginateAsync(page, limit);
    }
}
