using Application.Dtos;
using Domain.Models;
using MediatR;
using System.Runtime.CompilerServices;

namespace Application.Users.Queries.LoginUserQuery
{
    public class LoginUserQuery : IRequest<OperationResult<string>>
    {
        public LoginUserQuery(UserDto user)
        {
            UserDto = user;
        }
        public UserDto UserDto { get; }
    }
}
