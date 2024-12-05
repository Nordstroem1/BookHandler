using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Domain.Models;
using MediatR;
using Application.Books.Commands.CreateBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Commands.DeleteBook;
using Application.Books.Queries.GetAllBooks;
using Application.Books.Queries.GetById;
using Microsoft.AspNetCore.Authorization;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetAllBooks")]
        [SwaggerOperation("Retrieves all the books from the database.")]
        public IActionResult GetAllBooks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mediator.Send(new GetAllBooksQuery()).Result;

            if(!result.IsSuccess)
            {
                return BadRequest(new {result.ErrorMessage, result.Data, result.IsSuccess});
            }

            return Ok(new { result.ErrorMessage, result.Data, result.IsSuccess });
        }

        [Authorize]
        [HttpGet("GetBookById")]
        [SwaggerOperation("Retrieves a book from the database by id.")]
        public IActionResult GetBook([FromQuery] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _mediator.Send(new GetBookByIdQuery(Guid.Parse(id))).Result;

                if (!result.IsSuccess)
                {
                    return BadRequest(new { result.ErrorMessage, result.Data, result.IsSuccess });
                }

                return Ok(new { result.ErrorMessage, result.Data, result.IsSuccess });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("CreateBook")]
        [SwaggerOperation("Adds a book to the database.")]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = _mediator.Send(new CreateBookCommand(book)).Result;

                if (!result.IsSuccess)
                {
                    return BadRequest(new {result.ErrorMessage, result.Data, result.IsSuccess});
                }

                return Ok(new { result.ErrorMessage, result.Data, result.IsSuccess });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("UpdateBook")]
        [SwaggerOperation("Updates a book in the database.")]
        public IActionResult UpdateBook([FromQuery] string idOfChosenBook, [FromBody] Book book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var bookUpdated = _mediator.Send(new UpdateBookCommand(book)).Result;

                if (!bookUpdated.IsSuccess)
                {
                    return BadRequest(OperationResult<Book>.Fail("Could not update the book"));
                }

                return Ok(OperationResult<Book>.Success(book));
            }
            catch(Exception ex)
            {
                return BadRequest(OperationResult<Book>.Fail(ex.Message));
            }
        }

        [Authorize]
        [HttpDelete("DeleteBook")]
        [SwaggerOperation("Deletes a book from the database.")]
        public IActionResult DeleteBook([FromQuery] string id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = _mediator.Send(new DeleteBookCommand(id)).Result;

                if (!result.IsSuccess)
                {
                    return BadRequest(OperationResult<bool>.Fail("Could not delete book"));
                }

                return Ok(OperationResult<bool>.Success(true));
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
