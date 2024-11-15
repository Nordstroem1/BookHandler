using Application.Dtos;
using Application.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using AutoMapper;
namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly FakeDatabase _database;
        private readonly IMapper _mapper;
        public BookService(FakeDatabase database, IMapper mapper)
        {
            _mapper = mapper;
            _database = database;
        }
        public List<Book> GetAllBooks()
        {
            try
            {
                List<Book> booklist = _database.GetAllBooks();

                if (booklist.Count == 0)
                {
                    throw new Exception("No books found");
                }

                return booklist;
            }
            catch
            {
                throw new Exception("No books found");
            }
        }
        public BookDto GetBook(Guid id)
        {
            try
            {
                Book foundBook = _database.GetBook(id);

                if (foundBook == null)
                {
                    throw new Exception("Book not found");
                }

                return _mapper.Map<BookDto>(foundBook);
            }
            catch
            {
                throw new Exception("Book not found");
            }
        }
        public bool AddBook(Book book)
        {
            try
            {
                bool bookAdded = _database.AddBook(book);

                if (bookAdded)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception("Something went wrong when adding the book.");
            }
        }
        public bool UpdateBook(Guid id, Book book)
        {
            try
            {
                bool bookUpdated = _database.UpdateBook(id, book);
                if (!bookUpdated)
                {
                    throw new Exception("Book not found");
                }
                return true;
            }
            catch
            {
                throw new Exception("Something went wrong when updating the book.");
            }
        }
        public bool DeleteBook(Guid id)
        {
            try
            {
                bool bookDeleted = _database.DeleteBook(id);
                if (!bookDeleted)
                {
                    throw new Exception("Book not found");
                }
                return true;
            }
            catch
            {
                throw new Exception("Something went wrong when deleting the book.");
            }
        }
    }
}