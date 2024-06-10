
using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Courses
{
    public static class CourseErros
    {
        public static readonly Error NotFound = new(
        "Course.NotFound",
        "The Cousrsr the specified identifier was not found");
    }
}
