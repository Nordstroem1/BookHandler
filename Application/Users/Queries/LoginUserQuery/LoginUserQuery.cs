using Application.Dtos;
using MediatR;

namespace Application.Users.Queries.LoginUserQuery
{
    public class LoginUserQuery : IRequest<string>
    {
        public LoginUserQuery(UserDto user)
        {
            UserDto = user;
        }
        public UserDto UserDto { get; }
    }
}
