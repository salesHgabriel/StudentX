using Companyx.Companyx.Studentx.Application.Users.GetAllStudents;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace Companyx.Companyx.Studentx.Infrastructure.Queries.Students
{
    public class GetAllStudentsQuery : IGetAllStudentsQuery
    {
        private readonly AppDbContext _db;

        public GetAllStudentsQuery(AppDbContext db)
        {
            _db = db;
        }

        public Task<List<GetAllStudentResponse>> FindAsync()
        => _db.Students
                .Select(s => new GetAllStudentResponse(s.UserId, s.User.UserName!, s.User.Email!, s.AssocitedAtUTC))
                .ToListAsync();
    }
}