using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using MediatR;
using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.UpdateAuthor;
using Application.Authors.Commands.DeleteAuthor;
using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthorById;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IMediator mediator, ILogger<AuthorController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("GetAuhtor")]
        [SwaggerOperation("Retrieves an author from the database by id.")]
        public IActionResult GetAuthorById([FromQuery] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mediator.Send(new GetAuthorByIdQuery(Guid.Parse(id))).Result;

            if (!result.IsSuccess)
            {
                _logger.LogError("Could not get author by id.");
                return BadRequest(new { result.Data, result.IsSuccess, result.ErrorMessage });
            }

            _logger.LogInformation("Author retrieved successfully.");
            return Ok(new { result.Data, result.IsSuccess, result.ErrorMessage });
        }

        [Authorize]
        [HttpGet("GetAllAuthors")]
        [SwaggerOperation("Retrieves all the result from the database.")]
        public IActionResult GetAllAuthors()
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Model state is not valid.");
                return BadRequest(ModelState);
            }

            try
            {
                var result = _mediator.Send(new GetAllAuthorsQuery()).Result;

                if (!result.IsSuccess)
                {
                    _logger.LogError("Could not get all authors.");
                    return BadRequest(new { result.Data, result.IsSuccess, result.ErrorMessage });
                }
                _logger.LogInformation("Authors retrieved successfully.");
                return Ok(new { result.Data, result.IsSuccess, result.ErrorMessage });
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [Authorize]
        [HttpPost("CreateAuthor")]
        [SwaggerOperation("Adds an author to the database.")]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mediator.Send(new CreateAuthorCommand(author)).Result;

            if (!result.IsSuccess)
            {
                _logger.LogWarning("Could not add author.");
                return BadRequest(new { result.Data, result.IsSuccess, result.ErrorMessage });
            }

            _logger.LogWarning("Author added successfully.");
            return Ok(new { result.Data, result.IsSuccess, result.ErrorMessage });
        }
        [Authorize]
        [HttpPut("UpdateAuthor")]
        [SwaggerOperation("Updates an author in the database.")]
        public IActionResult UpdateAuthor([FromQuery] string id, [FromBody] Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mediator.Send(new UpdateAuthorCommand(author)).Result;

            if (!result.IsSuccess)
            {
                _logger.LogError("Could not update author.");
                return BadRequest(new { result.Data, result.ErrorMessage, result.IsSuccess });
            }

            _logger.LogInformation("Author updated successfully.");
            return Ok(new { result.Data, result.IsSuccess, result.ErrorMessage });
        }
        [Authorize]
        [HttpDelete("DeleteAuthor")]
        [SwaggerOperation("Deletes an author from the database with UserId")]
        public IActionResult DeleteAuthor([FromQuery] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mediator.Send(new DeleteAuthorCommand(Guid.Parse(id))).Result;

            if (!result.IsSuccess)
            {
                _logger.LogError("Could not delete author.");
                return BadRequest(new {result.Data, result.ErrorMessage, result.IsSuccess});
            }

            return Ok(new { result.Data, result.IsSuccess, result.ErrorMessage });
        }
    }
}
