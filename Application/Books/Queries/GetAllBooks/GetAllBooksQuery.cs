using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<OperationResult<List<Book>>>
    {
        public GetAllBooksQuery()
        {
            Booklist = new List<Book>();
        }
        public List<Book> Booklist { get; }
    }
}
