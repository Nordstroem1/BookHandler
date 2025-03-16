using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;
namespace Application.Users.Queries.LoginUserQuery
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, OperationResult<string>>
    {
        private readonly IGenericRepository<User> _genericRepository;
        private TokenHelper _tokenHelper { get; set; }
        public LoginUserQueryHandler(IGenericRepository<User> genericRepository, TokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var foundUsers = await _genericRepository.Find(u => u.UserName == request.UserDto.UserName);
            var foundUser = foundUsers.FirstOrDefault();

            if (foundUser != null && BCrypt.Net.BCrypt.Verify(request.UserDto.Password, foundUser.Password))
            {
                string token = _tokenHelper.GenerateToken(foundUser);

                return OperationResult<string>.Success(token);
            }
            else
            {
                return OperationResult<string>.Fail("Invalid username or password.");
            }
        }
    }
}