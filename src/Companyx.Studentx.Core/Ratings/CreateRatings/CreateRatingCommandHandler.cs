using Companyx.Companyx.Studentx.Application.Abstractions.Authentication;
using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Ratings;

namespace Companyx.Companyx.Studentx.Core.Ratings.CreateRatings
{
    public sealed class CreateRatingCommandHandler : ICommandHandler<CreateRatingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserContext _userContext;

        public CreateRatingCommandHandler(IUnitOfWork unitOfWork, IRatingRepository ratingRepository, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _ratingRepository = ratingRepository;
            _userContext = userContext;
        }

        public async Task<Result<bool>> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = Rating.Create(request.Start, request.Comment, request.CourseId, _userContext.UserId);

            if (rating.IsFailure)
            {
                return Result.Failure<bool>(RatingErros.NotFound);
            }

            await _ratingRepository.AddAsync(rating.Value, cancellationToken);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}