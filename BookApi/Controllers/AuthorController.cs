using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using MediatR;
using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.UpdateAuthor;
using Application.Authors.Commands.DeleteAuthor;
using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthorById;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [Authorize]
        [HttpGet("GetAuhtor")]
        public IActionResult GetAuthorById([FromQuery] string id)
        {
            try
            {
                var authorDto = _mediator.Send(new GetAuthorByIdQuery(Guid.Parse(id))).Result;

                if (authorDto == null) 
                { 
                    return NotFound("Author not found"); 
                }

                return Ok(authorDto);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpGet("GetAllAuthors")]
        public IActionResult GetAllAuthors()
        {
            try
            {
                var authors = _mediator.Send(new GetAllAuthorsQueryHandler()).Result;

                return authors.Count == 0 ? NotFound("No authors in list") : Ok(authors);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPost("CreateAuthor")]
        public IActionResult AddAuthor([FromBody] Author author)
        {
            try
            {
                bool authorAdded = _mediator.Send(new CreateAuthorCommand(author)).Result;
                if (authorAdded)
                {
                    return Ok("Author added");
                }
                else
                {
                    return BadRequest("Could not add Author.");
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPut("UpdateAuthor")]
        public IActionResult UpdateAuthor([FromQuery] string id, [FromBody] Author author)
        {
            try
            {
                bool authorUpdated = _mediator.Send(new UpdateAuthorCommand(author)).Result;

                if (authorUpdated)
                {
                    return Ok("Author updated");
                }
                else
                {
                    return BadRequest("Could not update Author.");
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpDelete("DeleteAuthor")]
        public IActionResult DeleteAuthor([FromQuery] string id)
        {
            try
            {
                bool authorDeleted = _mediator.Send(new DeleteAuthorCommand(Guid.Parse(id))).Result;
                
                if (authorDeleted)
                {
                    return Ok("Author deleted");
                }
                else
                {
                    return BadRequest("Could not delete Author.");
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
