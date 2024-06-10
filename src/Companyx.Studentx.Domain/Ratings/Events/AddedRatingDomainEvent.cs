using Companyx.Companyx.Studentx.Domain.Abstraction;

namespace Companyx.Companyx.Studentx.Domain.Ratings.Events
{
    public sealed class AddedRatingDomainEvent(Guid RatingId) : IDomainEvent;
}
