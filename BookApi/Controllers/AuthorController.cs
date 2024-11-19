//using Microsoft.AspNetCore.Mvc;
//using Application.Services;
//using Domain.Models;
//using Application.Dtos;

//namespace BookApi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AuthorController : Controller
//    {
//        private readonly AuthorService _authorService;

//        public AuthorController(AuthorService authorService)
//        {
//            _authorService = authorService;
//        }

//        [HttpGet("GetAuhtor")]
//        public IActionResult GetAuthor([FromQuery] string id)
//        {
//            try
//            {
//                AuthorDto authorDto = _authorService.GetAuthor(Guid.Parse(id));
//                if (authorDto == null) { return NotFound("Author not found"); }

//                return Ok(authorDto);
//            }
//            catch
//            {
//                return StatusCode(500, "Internal server error");
//            }
//        }

//        [HttpGet("GetAllAuthors")]
//        public IActionResult GetAllAuthors()
//        {
//            try
//            {
//                var authors = _authorService.GetAllAuthors();
//                return authors.Count == 0 ? NotFound("No authors in list") : Ok(authors);
//            }
//            catch
//            {
//                return StatusCode(500, "Internal server error");
//            }
//        }

//        [HttpPost("AddAuthor")]
//        public IActionResult AddAuthor([FromBody] Author author)
//        {
//            try
//            {
//                bool authorAdded = _authorService.AddAuthor(author);
//                if (authorAdded)
//                {
//                    return Ok("Author added");
//                }
//                else
//                {
//                    return BadRequest("Could not add Author.");
//                }
//            }
//            catch
//            {
//                return StatusCode(500, "Internal server error");
//            }
//        }

//        [HttpPut("UpdateAuthor")]
//        public IActionResult UpdateAuthor([FromQuery] string id, [FromBody] Author author)
//        {
//            try
//            {
//                bool authorUpdated = _authorService.UpdateAuthor(Guid.Parse(id), author);

//                if (authorUpdated)
//                {
//                    return Ok("Author updated");
//                }
//                else
//                {
//                    return BadRequest("Could not update Author.");
//                }
//            }
//            catch
//            {
//                return StatusCode(500, "Internal server error");
//            }
//        }
//        [HttpDelete("DeleteAuthor")]
//        public IActionResult DeleteAuthor([FromQuery] string id)
//        {
//            try
//            {
//                bool authorDeleted = _authorService.DeleteAuthor(Guid.Parse(id));
//                if (authorDeleted)
//                {
//                    return Ok("Author deleted");
//                }
//                else
//                {
//                    return BadRequest("Could not delete Author.");
//                }
//            }
//            catch
//            {
//                return StatusCode(500, "Internal server error");
//            }
//        }
//    }
//}
