

namespace Companyx.Companyx.Studentx.Application.Courses.GetAllCourseWithRatingAndStudent
{
    public class AllCourseWithRatingAndStudentResponse
    {
        public Guid CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? CourseDescription { get; set; }
        public IEnumerable<RatingsAndStudentOfCourseResponse> Ratings { get; set; } = default!;

        public class RatingsAndStudentOfCourseResponse
        {
            public Guid RatingId { get; set; }
            public Guid StudentId { get; set; }
            public int Rating { get; set; }
            public string? Comments { get; set; }
            public DateTime CreatedRatingUTC { get; set; }
        }
    }
}
