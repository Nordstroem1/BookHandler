using Domain.Models;
using MediatR;
namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsCommand : IRequest<List<Author>>
    {
        public GetAllAuthorsCommand() 
        {
            Authors = new List<Author>();
        }
        public List<Author> Authors { get;}
    }
}
