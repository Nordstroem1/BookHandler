using Application.Dtos;
using MediatR;
namespace Application.Books.Queries.Books
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public GetBookByIdQuery(BookDto bookDto)
        {
            BookDto = bookDto;
        }
        public BookDto BookDto { get; }
    }
}
