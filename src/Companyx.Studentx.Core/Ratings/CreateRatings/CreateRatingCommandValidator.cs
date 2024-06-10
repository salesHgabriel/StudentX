
using FluentValidation;

namespace Companyx.Companyx.Studentx.Core.Ratings.CreateRatings
{
    public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
    {
        public CreateRatingCommandValidator()
        {
            RuleFor(c => c.Start).NotEmpty();
            RuleFor(c => c.Start).InclusiveBetween(1, 5);
        }
    }
}
