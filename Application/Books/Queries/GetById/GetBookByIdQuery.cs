using Application.Dtos;
using MediatR;

namespace Application.Books.Queries.GetById
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public GetBookByIdQuery(Guid bookId)
        {
            BookId = bookId;
        }
        public Guid BookId { get; }
    }
}
