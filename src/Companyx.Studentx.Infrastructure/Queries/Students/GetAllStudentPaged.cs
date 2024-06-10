using Companyx.Companyx.Studentx.Application.Users.GetAllStudents;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using ShortCleanLinqExtensions.src.Extensions;
using ShortCleanLinqExtensions.src.Utils.PaginatorHelper;

namespace Companyx.Companyx.Studentx.Infrastructure.Queries.Students
{
    public class GetAllStudentPaged : IGetAllStudentPagedQuery
    {
        private readonly AppDbContext _db;

        public GetAllStudentPaged(AppDbContext db)
        {
            _db = db;
        }

        public Task<PagedResponse<GetAllStudentResponse>> FindAsync(int page = 1, int limit = 15)
           => _db.Students
                .Select(s => new GetAllStudentResponse(s.UserId, s.User.UserName!, s.User.Email!, s.AssocitedAtUTC))
                .PaginateAsync(page, limit);
    }
}
