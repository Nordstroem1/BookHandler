using Application.Dtos;
using Domain.Models;
using MediatR;
namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<OperationResult<AuthorDto>>
    {
        public GetAuthorByIdQuery(Guid authorId)
        {
            AuthorId = authorId;
        }
        public Guid AuthorId { get; }
    }
}
