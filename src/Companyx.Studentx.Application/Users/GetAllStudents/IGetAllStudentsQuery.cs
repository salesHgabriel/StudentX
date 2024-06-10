using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;

namespace Companyx.Companyx.Studentx.Application.Users.GetAllStudents
{
    public interface IGetAllStudentsQuery : IScopedService
    {
        Task<List<GetAllStudentResponse>> FindAsync();
    }
}
