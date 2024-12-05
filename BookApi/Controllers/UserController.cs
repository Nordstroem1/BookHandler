using Application.Dtos;
using Application.Users.Commands.RegisterUserCommand;
using Application.Users.Queries.GetAllUsersQuery;
using Application.Users.Queries.LoginUserQuery;
using Domain.Models;
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
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            try
            {
                var result = _mediator.Send(new GetAllUsersQuery()).Result;

                if (!result.IsSuccess)
                {
                    return BadRequest(result.ErrorMessage);
                }

                return Ok(OperationResult<List<User>>.Success(result.Data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Register")]
        [SwaggerOperation("Registers a new user.")]
        public async Task<IActionResult> RegisterUser([FromBody]UserDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            var result = await _mediator.Send(new CreateUserCommand(newUser));

            return Ok(OperationResult<User>.Success(result.Data));
        }

        [HttpPost("Login")]
        [SwaggerOperation("Logs in a user and returns a token.")]
        public async Task<IActionResult> LoginUser([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            try
            {
                var response = await _mediator.Send(new LoginUserQuery(user));

                if (!response.IsSuccess)
                {
                    return BadRequest(response.ErrorMessage);
                }

                return Ok(OperationResult<string>.Success(response.Data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}