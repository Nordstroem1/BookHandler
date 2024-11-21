using Application.Dtos;
using MediatR;

namespace Application.Books.Queries.GetById
{
    public class GetBookByIdCommand : IRequest<BookDto>
    {
        public GetBookByIdCommand(Guid bookId)
        {
            BookId = bookId;
        }
        public Guid BookId { get; }
    }
}
