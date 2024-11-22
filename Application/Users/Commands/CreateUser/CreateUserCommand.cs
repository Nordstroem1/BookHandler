
using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.RegisterUserCommand
{
    public class CreateUserCommand : IRequest<User>
    {
        public CreateUserCommand(UserDto userDto) 
        {
            UserDto = userDto;
        }
        public UserDto UserDto { get;}
    }
}
