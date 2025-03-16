using Application.Dtos;
using Domain.Models;
using MediatR;
using System.Buffers;

namespace Application.Users.Commands.RegisterUserCommand
{
    public class CreateUserCommand : IRequest<OperationResult<User>>
    {
        public CreateUserCommand(UserDto userDto) 
        {
            UserDto = userDto;
        }
        public UserDto UserDto { get;}
    }
}
