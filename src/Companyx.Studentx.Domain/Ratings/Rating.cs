using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Courses;
using Companyx.Companyx.Studentx.Domain.Ratings.Events;
using Companyx.Companyx.Studentx.Domain.Users;

namespace Companyx.Companyx.Studentx.Domain.Ratings
{
    public class Rating : EntityRoot
    {
        public Rating()
        {
            
        }
        public Rating(int star, string? comment, Guid courseId, Guid userId)
        {
            Start = star;
            Comment = comment;
            CourseId = courseId;
            UserId = userId;
        }

        public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");


        public int Start { get; private set; }
        public string? Comment { get; private set; }
        public Guid CourseId { get; private set; }
        public virtual Course Course { get; } = null!;
        public Guid UserId { get; private set; }
        public virtual User User { get; } = null!;

        public static Result<Rating> Create(int star, string? comment, Guid courseId, Guid userId)
        {
            var rating = new Rating(star, comment,courseId,  userId);

            if (rating.Start < 1 || rating.Start > 5)
            {
                return Result.Failure<Rating>(Invalid);
            }

            rating.RaiseDomainEvent(new AddedRatingDomainEvent(rating.Id));

            return rating;

        }

        public void UpdateExisting(int star, string? comment, Guid userId)
        {
            Start = star;
            Comment = comment;
            UserId = userId;
        }

    }
}