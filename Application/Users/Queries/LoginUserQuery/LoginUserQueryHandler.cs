using Infrastructure.Databases;
using MediatR;
namespace Application.Users.Queries.LoginUserQuery
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private FakeDatabase _fakeDatabase { get; set; }
        private TokenHelper _tokenHelper { get; set; }
        public LoginUserQueryHandler(FakeDatabase fakeDatabase, TokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _fakeDatabase = fakeDatabase;
        }
        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var foundUser = _fakeDatabase.LoginUser(request.UserDto.UserName, request.UserDto.Password);

            if (foundUser != null)
            {
                string token = _tokenHelper.GenerateToken(foundUser);

                return Task.FromResult(token);
            }
            else
            {
                return Task.FromResult("Login failed");
            }
        }
    }
}