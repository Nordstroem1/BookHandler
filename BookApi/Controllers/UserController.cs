using Application.Dtos;
using Application.Users.Commands.RegisterUserCommand;
using Application.Users.Queries.GetAllUsersQuery;
using Application.Users.Queries.LoginUserQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetUser")]
        [SwaggerOperation("Retrieves all users from the database.")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var listOfUsers = _mediator.Send(new GetAllUsersQuery()).Result;

                return listOfUsers.Count == 0 ? NotFound("No users in list") : Ok(listOfUsers);
            }
            catch
            {
                return StatusCode(500, "Could not get all users from Database.");
            }
        }
        [HttpPost("Register")]
        [SwaggerOperation("Registers a new user.")]
        public async Task<IActionResult> RegisterUser([FromBody]UserDto newUser)
        {
            return Ok(await _mediator.Send(new CreateUserCommand(newUser)));
        }

        [HttpPost("Login")]
        [SwaggerOperation("Logs in a user and returns a token.")]
        public async Task<IActionResult> LoginUser([FromBody] UserDto user)
        {
            var response = await _mediator.Send(new LoginUserQuery(user));
            return response == null ? NotFound("User not found") : Ok(response);
        }
    }
}