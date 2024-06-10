
using Companyx.Companyx.Studentx.Core.Ratings.UpdateRatings;
using FluentValidation;

namespace Companyx.Companyx.Studentx.Core.Ratings.CreateRatings
{
    public class UpdateRatingCommandValidator : AbstractValidator<UpdateRatingCommand>
    {
        public UpdateRatingCommandValidator()
        {
            RuleFor(c => c.Start).NotEmpty();
            RuleFor(c => c.Start).InclusiveBetween(1, 5);
            RuleFor(c => c.Id).NotNull();
        }
    }
}
