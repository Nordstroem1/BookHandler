using Application.Dtos;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        BookDto GetBook(Guid id);
        bool AddBook(Book book);
        bool UpdateBook(Guid id, Book book);
        bool DeleteBook(Guid id);
    }
}
