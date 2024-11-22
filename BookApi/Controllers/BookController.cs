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
            try
            {
                var bookList = _mediator.Send(new GetAllBooksQueryHandler()).Result;
                return bookList.Count == 0 ? NotFound("No books in list") : Ok(bookList);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [Authorize]
        [HttpGet("GetBookById")]
        [SwaggerOperation("Retrieves a book from the database by id.")]
        public IActionResult GetBook([FromQuery] string id)
        {
            try
            {
                var bookDto = _mediator.Send(new GetBookByIdQuery(Guid.Parse(id))).Result;

                if (bookDto == null) { return NotFound("Book not found"); }

                return Ok(bookDto);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPost("CreateBook")]
        [SwaggerOperation("Adds a book to the database.")]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                bool bookAdded = _mediator.Send(new CreateBookCommand(book)).Result;

                if (bookAdded)
                {
                    return Ok("Book added");
                }
                else
                {
                    return BadRequest("Something went wrong while adding the book.");
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpPut("UpdateBook")]
        [SwaggerOperation("Updates a book in the database.")]
        public IActionResult UpdateBook([FromQuery] string idOfChosenBook, [FromBody] Book book)
        {
            try
            {
                bool bookUpdated = _mediator.Send(new UpdateBookCommand(book)).Result;

                if (bookUpdated)
                {
                    return Ok("Book updated");
                }
                else
                {
                    return BadRequest("Something went wrong while updating the book.");
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [Authorize]
        [HttpDelete("DeleteBook")]
        [SwaggerOperation("Deletes a book from the database.")]
        public IActionResult DeleteBook([FromQuery] string id)
        {
            try
            {
                bool bookDeleted = _mediator.Send(new DeleteBookCommand(id)).Result;
                if (bookDeleted)
                {
                    return Ok("Book deleted");
                }
                else
                {
                    return BadRequest("Something went wrong while deleting the book.");
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
