using Companyx.Companyx.Studentx.Application.Users.CreateUsers;
using Companyx.Companyx.Studentx.Application.Users.GetAllStudents;
using Companyx.Companyx.Studentx.Application.Users.UpdateUser;
using Companyx.Companyx.Studentx.Core.Students.CreateUser;
using Companyx.Companyx.Studentx.Core.Students.DeleteUser;
using Companyx.Companyx.Studentx.Core.Students.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Companyx.Studentx.API.Controllers.Users
{
    [ApiController]
    [ApiVersion(ApiVersions.V1)]
    [Route("api/v{version:apiVersion}/students")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly ISender _sender;

        public StudentsController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents([FromServices] IGetAllStudentsQuery query)
        {
            var result = await query.FindAsync();
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateStudent(
            CreateUserRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand(
                request.Name,
                request.Email,
                request.PassWord,
                null);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return CreatedAtAction(nameof(GetStudents), result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id,
            UpdateUserRequest request,
            CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand(
                id,
                request.Name);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand(id);

            var result = await _sender.Send(command, cancellationToken);

            if (result.IsFailure) return BadRequest(result.Error);

            return Ok(result.Value);
        }
    }
}