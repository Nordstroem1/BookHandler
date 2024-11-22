using Domain.Models;
using MediatR;
namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequest<List<Author>>
    {
        public GetAllAuthorsQueryHandler() 
        {
            Authors = new List<Author>();
        }
        public List<Author> Authors { get;}
    }
}
