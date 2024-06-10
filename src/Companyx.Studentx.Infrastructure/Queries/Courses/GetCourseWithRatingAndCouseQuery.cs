using Companyx.Companyx.Studentx.Application.Courses.GetAllCourseWithRatingAndStudent;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using ShortCleanLinqExtensions.src.Extensions;
using ShortCleanLinqExtensions.src.Utils.PaginatorHelper;

namespace Companyx.Companyx.Studentx.Infrastructure.Queries.Courses
{
    public class GetCourseWithRatingAndCouseQuery : IGetCourseWithRatingAndCouseQuery
    {
        private readonly AppDbContext _db;

        public GetCourseWithRatingAndCouseQuery(AppDbContext db)
        {
            _db = db;
        }

        public Task<PagedResponse<AllCourseWithRatingAndStudentResponse>> FindAsync(int page = 1, int limit = 15)
            => _db.Courses
                .Select(c => new AllCourseWithRatingAndStudentResponse()
                {
                    CourseId = c.Id,
                    CourseName = c.Name,
                    CourseDescription  = c.Description,
                    Ratings = c.Ratings.Select(r => new AllCourseWithRatingAndStudentResponse.RatingsAndStudentOfCourseResponse()
                    {
                        RatingId = r.Id,
                        Rating = r.Start,
                        Comments = r.Comment,
                        CreatedRatingUTC = r.CreatedAtUTC,
                        StudentId = r.UserId
                    })
                }).PaginateAsync(page, limit);
    }
}
