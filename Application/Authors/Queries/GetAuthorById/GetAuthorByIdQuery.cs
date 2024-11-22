using Application.Dtos;
using MediatR;
namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorDto>
    {
        public GetAuthorByIdQuery(Guid authorId)
        {
            AuthorId = authorId;
        }
        public Guid AuthorId { get; }
    }
}
