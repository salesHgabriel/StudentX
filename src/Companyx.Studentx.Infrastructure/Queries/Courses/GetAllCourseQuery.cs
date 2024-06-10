using Companyx.Companyx.Studentx.Application.Abstractions.Data;
using Companyx.Companyx.Studentx.Application.Courses.GetCourses;
using Dapper;


namespace Companyx.Companyx.Studentx.Infrastructure.Queries.Courses
{
    public class GetAllCourseQuery : IGetAllCourseQuery
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public GetAllCourseQuery(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<GetAllCoursesResponse>> FindAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            const string sql = """
            SELECT c.id As Id, 
            c.name As Name, 
            c.description As Description
            FROM courses c;
            """;

            return await connection.QueryAsync<GetAllCoursesResponse>(sql);
        }
    }
}