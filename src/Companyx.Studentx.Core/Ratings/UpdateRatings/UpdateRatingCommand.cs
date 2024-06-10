using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;


namespace Companyx.Companyx.Studentx.Core.Ratings.UpdateRatings
{
    public sealed record UpdateRatingCommand(Guid Id, int Start, string? Comment, Guid CourseId) : ICommand<bool>;
}
