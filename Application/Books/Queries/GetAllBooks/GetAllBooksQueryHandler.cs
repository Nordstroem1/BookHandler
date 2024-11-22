using Domain.Models;
using MediatR;

namespace Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequest<List<Book>>
    {
        public GetAllBooksQueryHandler()
        {
            Booklist = new List<Book>();
        }
        public List<Book> Booklist { get; }
    }
}
