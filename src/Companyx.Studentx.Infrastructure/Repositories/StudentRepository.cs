using Companyx.Companyx.Studentx.Domain.Students;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;

namespace Companyx.Companyx.Studentx.Infrastructure.Repositories
{
    internal class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Student> AddUserOnSchoolAsync(Guid userId, Guid schoolId)
        {
            var student = Student.Create(userId, schoolId);

            await AddAsync(student);

            return student;
        }
    }
}