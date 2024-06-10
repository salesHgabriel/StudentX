using Companyx.Companyx.Studentx.Application.Abstractions.Messaging;
using Companyx.Companyx.Studentx.Domain.Abstraction;
using Companyx.Companyx.Studentx.Domain.Ratings;

namespace Companyx.Companyx.Studentx.Core.Ratings.DeleteRatings
{
    public sealed class DeleteRatingCommandHandler : ICommandHandler<DeleteRatingCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRatingRepository _ratingRepository;

        public DeleteRatingCommandHandler(IUnitOfWork unitOfWork, IRatingRepository ratingRepository)
        {
            _unitOfWork = unitOfWork;
            _ratingRepository = ratingRepository;
        }

        public async Task<Result<bool>> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.GetByIdAsync(request.Id, cancellationToken);

            if (rating is null)
            {
                return Result.Failure<bool>(RatingErros.NotFound);
            }

            rating.Remove();

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}