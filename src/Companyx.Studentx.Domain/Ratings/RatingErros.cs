using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Ratings
{
    public static class RatingErros
    {
        public static readonly Error NotFound = new(
       "Rating.NotFound",
       "The rating the specified identifier was not found");
    }
}
