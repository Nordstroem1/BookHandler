using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetById
{
    public class GetBookByIdQuery : IRequest<OperationResult<BookDto>>
    {
        public GetBookByIdQuery(Guid bookId)
        {
            BookId = bookId;
        }
        public Guid BookId { get; }
    }
}
