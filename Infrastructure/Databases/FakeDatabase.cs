using Domain.Models;
namespace Infrastructure.Databases
{
    public class FakeDatabase
    {
        private List<Book> Books = new List<Book>();
        public FakeDatabase()
        {
            Books = new List<Book>
            {
                new Book(Guid.NewGuid(), "The Great Gatsby", "F. Scott Fitzgerald", 1925),
                new Book(Guid.NewGuid(), "To Kill a Mockingbird", "Harper Lee", 1960),
                new Book(Guid.NewGuid(), "1984", "George Orwell", 1949),
                new Book(Guid.NewGuid(), "The Catcher in the Rye", "J.D. Salinger", 1951),
                new Book(Guid.NewGuid(), "The Grapes of Wrath", "John Steinbeck", 1939),
                new Book(Guid.NewGuid(), "The Lord of the Rings", "J.R.R. Tolkien", 1954),
                new Book(Guid.NewGuid(), "The Hobbit", "J.R.R. Tolkien", 1937),
            };
        }
        public List<Book> GetAllBooks()
        {
            return Books;
        }
        public Book? GetBook(Guid id)
        {
            return Books.FirstOrDefault(book => book.Id == id);
        }
        public bool AddBook(Book book)
        {
            Books.Add(book);
            return true;
        }
        public bool UpdateBook(Guid id, Book updatedBook)
        {
            Book foundBook = Books.FirstOrDefault(book => book.Id == id);

            if (foundBook != null)
            {
                foundBook.Id = updatedBook.Id;
                foundBook.Title = updatedBook.Title;
                foundBook.Author = updatedBook.Author;
                foundBook.Pages = updatedBook.Pages;
            }
            else
            {

                return false;
            }

            return true;
        }
        public bool DeleteBook(Guid id)
        {
            Book foundBook = Books.FirstOrDefault(book => book.Id == id);
            if (foundBook != null)
            {
                Books.Remove(foundBook);
            }
            else
            {

                return false;
            }

            return true;
        }
    }
}
