using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetAllUsersQuery
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
        public GetAllUsersQuery()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; set; }
    }
}
