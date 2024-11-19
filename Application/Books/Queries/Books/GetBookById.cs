using Application.Dtos;
using MediatR;
namespace Application.Books.Queries.Books
{
    public class GetBookById : IRequest<BookDto>
    {
        public GetBookById(BookDto bookDto)
        {
            BookDto = bookDto;
        }
        public BookDto BookDto { get; }
    }
}
