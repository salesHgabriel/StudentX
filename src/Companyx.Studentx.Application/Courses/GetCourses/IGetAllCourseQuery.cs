using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;

namespace Companyx.Companyx.Studentx.Application.Courses.GetCourses
{
    public interface IGetAllCourseQuery : IScopedService
    {
        Task<IEnumerable<GetAllCoursesResponse>> FindAsync();
    }
}
