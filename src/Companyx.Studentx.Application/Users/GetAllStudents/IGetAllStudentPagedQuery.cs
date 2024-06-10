using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;
using ShortCleanLinqExtensions.src.Utils.PaginatorHelper;

namespace Companyx.Companyx.Studentx.Application.Users.GetAllStudents
{
    public interface IGetAllStudentPagedQuery : IScopedService
    {
        Task<PagedResponse<GetAllStudentResponse>> FindAsync(int page = 1, int limit = 15);
    }
}
