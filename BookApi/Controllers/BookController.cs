using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Application.Services;
using Application.Dtos;
using Domain.Models;
namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        [SwaggerOperation("Retrieves all the books from the database.")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();
                return books.Count == 0 ? NotFound("No books in list") : Ok(books);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetBook")]
        [SwaggerOperation("Retrieves a book from the database.")]
        public IActionResult GetBook([FromQuery] string id)
        {
            try
            {
                BookDto bookDto = _bookService.GetBook(Guid.Parse(id));

                if (bookDto == null) { return NotFound("Book not found"); }

                return Ok(bookDto);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddBook")]
        [SwaggerOperation("Adds a book to the database.")]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                bool bookAdded = _bookService.AddBook(book);

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
        [SwaggerOperation("Updates a book in the database.")]
        public IActionResult UpdateBook([FromQuery] string idOfChosenBook, [FromBody] Book book)
        {
            try
            {
                bool bookUpdated = _bookService.UpdateBook(Guid.Parse(idOfChosenBook), book);

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
        [SwaggerOperation("Deletes a book from the database.")]
        public IActionResult DeleteBook([FromQuery] string id)
        {
            try
            {
                bool bookDeleted = _bookService.DeleteBook(Guid.Parse(id));
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
