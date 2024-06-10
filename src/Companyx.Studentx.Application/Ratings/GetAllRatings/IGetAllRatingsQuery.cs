using ShortCleanLinqExtensions.src.Utils.AutoRegisterDI;
using ShortCleanLinqExtensions.src.Utils.PaginatorHelper;

namespace Companyx.Companyx.Studentx.Application.Ratings.GetAllRatings
{
    public interface IGetAllRatingsQuery : IScopedService
    {
        Task<PagedResponse<GetAllRatingsResponse>> FindAsync(int page = 1, int limit = 1);
    }
}