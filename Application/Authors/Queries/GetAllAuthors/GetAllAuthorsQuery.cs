using Domain.Models;
using MediatR;
namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<OperationResult<List<Author>>>
    {
        public GetAllAuthorsQuery() 
        {
            Authors = new List<Author>();
        }
        public List<Author> Authors { get;}
    }
}
