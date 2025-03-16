using Application.Users.Commands.RegisterUserCommand;
using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OperationResult<User>>
    {
        private readonly IGenericRepository<User> _genericRepository;
        public CreateUserCommandHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        async Task<OperationResult<User>> IRequestHandler<CreateUserCommand, OperationResult<User>>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User(Guid.NewGuid(), request.UserDto.UserName, request.UserDto.Password);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            if (user == null)
            {
                return OperationResult<User>.Fail("Could not add user.");
            }
            await _genericRepository.AddAsync(user);

            return OperationResult<User>.Success(user);
        }
    }
}