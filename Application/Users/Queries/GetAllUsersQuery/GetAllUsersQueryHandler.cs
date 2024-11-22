using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Users.Queries.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly FakeDatabase _fakeDatabase;
        public GetAllUsersQueryHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var listOfUsers = _fakeDatabase.GetAllUsers();

            return Task.FromResult(listOfUsers);
        }
    }
}
