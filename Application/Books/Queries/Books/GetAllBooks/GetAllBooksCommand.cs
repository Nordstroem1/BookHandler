using Domain.Models;
using MediatR;

namespace Application.Books.Queries.Books.GetAllBooks
{
    public class GetAllBooksCommand : IRequest<List<Book>>
    {
        public GetAllBooksCommand() 
        {
            Booklist = new List<Book>();
        }
        public List<Book> Booklist { get;}
    }
}
