using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Application.Services;
using Application.Dtos;
using Domain.Models;
using MediatR;
using Application.Books.Commands.CreateBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Commands.DeleteBook;

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

        //[HttpGet("GetAllBooks")]
        //[OpenApiOperation("Retrieves all the books from the database.")]
        //public IActionResult GetAllBooks()
        //{
        //    try
        //    {
        //        var books = _bookService.GetAllBooks();
        //        return books.Count == 0 ? NotFound("No books in list") : Ok(books);
        //    }
        //    catch
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        //[HttpGet("GetBook")]
        //[OpenApiOperation("Retrieves a book from the database.")]
        //public IActionResult GetBook([FromQuery] string id)
        //{
        //    try
        //    {
        //        BookDto bookDto = _bookService.GetBook(Guid.Parse(id));

        //        if (bookDto == null) { return NotFound("Book not found"); }

        //        return Ok(bookDto);
        //    }
        //    catch
        //    {
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        [HttpPost("AddBook")]
        [OpenApiOperation("Adds a book to the database.")]
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
        [HttpPut("UpdateBook")]
        [OpenApiOperation("Updates a book in the database.")]
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
        [HttpDelete("DeleteBook")]
        [OpenApiOperation("Deletes a book from the database.")]
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
