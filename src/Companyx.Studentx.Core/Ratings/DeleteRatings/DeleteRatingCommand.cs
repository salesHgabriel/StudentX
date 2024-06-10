using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;

namespace Companyx.Companyx.Studentx.Core.Ratings.DeleteRatings
{
    public sealed record DeleteRatingCommand(Guid Id) : ICommand<bool>;
}