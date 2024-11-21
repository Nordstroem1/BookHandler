using Application.Dtos;
using MediatR;
namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdCommand : IRequest<AuthorDto>
    {
        public GetAuthorByIdCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
        public Guid AuthorId { get; }
    }
}
