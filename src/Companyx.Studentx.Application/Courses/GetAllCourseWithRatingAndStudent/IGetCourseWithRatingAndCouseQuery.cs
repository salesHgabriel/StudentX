using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;
using ShortCleanLinqExtensions.src.Utils.PaginatorHelper;

namespace Companyx.Companyx.Studentx.Application.Courses.GetAllCourseWithRatingAndStudent
{
    public interface IGetCourseWithRatingAndCouseQuery : IScopedService
    {
        Task<PagedResponse<AllCourseWithRatingAndStudentResponse>> FindAsync(int page = 1, int limit = 15);
    }
}
