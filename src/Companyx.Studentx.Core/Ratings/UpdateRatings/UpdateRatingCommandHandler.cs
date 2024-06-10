using Companyx.Companyx.Studentx.Application.Abstractions.Authentication;
using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Ratings;

namespace Companyx.Companyx.Studentx.Core.Ratings.UpdateRatings
{
    internal class UpdateRatingCommandHandle : ICommandHandler<UpdateRatingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserContext _userContext;

        public UpdateRatingCommandHandle(IUnitOfWork unitOfWork, IRatingRepository ratingRepository, IUserContext userContext)
        {
            _unitOfWork = unitOfWork;
            _ratingRepository = ratingRepository;
            _userContext = userContext;
        }

        public async Task<Result<bool>> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.GetByIdAsync(request.Id, cancellationToken);

            if (rating is null)
            {
                return Result.Failure<bool>(RatingErros.NotFound);
            }

            rating.UpdateExisting(request.Start, request.Comment, _userContext.UserId);

            rating.SetUpdateAt();

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
