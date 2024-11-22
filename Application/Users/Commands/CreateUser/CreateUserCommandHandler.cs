using Application.Dtos;
using Application.Users.Commands.RegisterUserCommand;
using AutoMapper;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly FakeDatabase _database;
        public CreateUserCommandHandler(FakeDatabase database)
        {
            _database = database;
        }
        Task<User> IRequestHandler<CreateUserCommand, User>.Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User(Guid.NewGuid(), request.UserDto.UserName, request.UserDto.Password);
            _database.AddUser(user);
            
            return Task.FromResult(user);
        }
    }
}
