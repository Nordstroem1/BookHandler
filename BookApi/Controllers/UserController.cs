using Application.Dtos;
using Application.Users.Commands.RegisterUserCommand;
using Application.Users.Queries.GetAllUsersQuery;
using Application.Users.Queries.LoginUserQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

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
        public async Task<IActionResult> RegisterUser([FromBody]UserDto newUser)
        {
            return Ok(await _mediator.Send(new CreateUserCommand(newUser)));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] UserDto user)
        {
            var response = await _mediator.Send(new LoginUserQuery(user));
            return response == null ? NotFound("User not found") : Ok(response);
        }
    }
}