using Companyx.Companyx.Studentx.Application.Courses.CreateCourse;
using Companyx.Companyx.Studentx.Application.Courses.GetAllCourseWithRatingAndStudent;
using Companyx.Companyx.Studentx.Application.Courses.GetCourses;
using Companyx.Companyx.Studentx.Application.Courses.UpdateCourse;
using Companyx.Companyx.Studentx.Core.Courses.CreateCourses;
using Companyx.Companyx.Studentx.Core.Courses.DeleteCourses;
using Companyx.Companyx.Studentx.Core.Courses.UpdateCourses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Companyx.Studentx.API.Controllers.Courses
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/courses")]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        private readonly ISender _sender;
       

        public CoursesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("with-rating")]
        public async Task<IActionResult> GetCoursesWithRatings([FromQuery] int page, [FromQuery] int limit, [FromServices] IGetCourseWithRatingAndCouseQuery query)
        {
            var result = await query.FindAsync(page, limit);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllCourses([FromServices] IGetAllCourseQuery query)
        {
            var result = await query.FindAsync();
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(
            CreateCourseRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateCourseCommand(
                request.Name,
                request.Description);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetAllCourses), result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] Guid id,
            UpdateCourseRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateCourseCommand(
                id,
                request.Name,
                request.Description);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteCourseCommad(id);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok(result);
        }
    }
}