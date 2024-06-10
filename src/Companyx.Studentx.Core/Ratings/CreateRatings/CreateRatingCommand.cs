using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;

namespace Companyx.Companyx.Studentx.Core.Ratings.CreateRatings
{
    public sealed record CreateRatingCommand(int Start, string? Comment, Guid CourseId) : ICommand<bool>;
}
