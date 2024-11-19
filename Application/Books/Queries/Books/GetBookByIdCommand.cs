using Application.Dtos;
using Infrastructure.Databases;
using MediatR;

namespace Application.Books.Queries.Books
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
