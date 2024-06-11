using Companyx.Companyx.Studentx.Application.Ratings.CreateRatings;
using Companyx.Companyx.Studentx.Application.Ratings.GetAllRatings;
using Companyx.Companyx.Studentx.Application.Ratings.UpdateRatings;
using Companyx.Companyx.Studentx.Core.Ratings.CreateRatings;
using Companyx.Companyx.Studentx.Core.Ratings.DeleteRatings;
using Companyx.Companyx.Studentx.Core.Ratings.UpdateRatings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Companyx.Studentx.API.Controllers.Ratings
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/ratings")]
    [Authorize]
    public class RatingsController : ControllerBase
    {
        private readonly ISender _sender;

        public RatingsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings([FromServices] IGetAllRatingsQuery query)
        {
            var result = await query.FindAsync();
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRating(
            CreateRatingRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateRatingCommand(
                request.Start,
                request.Comment,
                request.CourseId);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetAllRatings), result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRating([FromRoute] Guid id,
            UpdateRatingRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateRatingCommand(
                id,
                request.Start,
                request.Comment,
                request.CourseId);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRating([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteRatingCommand(id);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok(result.Value);
        }
    }
}