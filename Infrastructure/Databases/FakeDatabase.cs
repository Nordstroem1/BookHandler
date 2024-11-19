using Domain.Models;
using System.Diagnostics.Metrics;
namespace Infrastructure.Databases
{
    public class FakeDatabase
    {
        private List<Book> Books = new List<Book>();
        private List<Author> Authors = new List<Author>();
        public FakeDatabase()
        {
            var author1 = new Author(Guid.NewGuid(), "F. Scott Fitzgerald", new DateOnly(1896, 9, 24), "Saint Paul, Minnesota");
            var author2 = new Author(Guid.NewGuid(), "Harper Lee", new DateOnly(1926, 4, 28), "Monroeville, Alabama");
            var author3 = new Author(Guid.NewGuid(), "George Orwell", new DateOnly(1903, 6, 25), "Motihari, India");
            var author4 = new Author(Guid.NewGuid(), "J.D. Salinger", new DateOnly(1919, 1, 1), "New York City, New York");
            var author5 = new Author(Guid.NewGuid(), "John Steinbeck", new DateOnly(1902, 2, 27), "Salinas, California");
            var author6 = new Author(Guid.NewGuid(), "J.R.R. Tolkien", new DateOnly(1892, 1, 3), "Bloemfontein, South Africa");
            var author7 = new Author(Guid.NewGuid(), "Jane Austen", new DateOnly(1775, 12, 16), "Steventon, Hampshire");

            Authors = new List<Author> { author1, author2, author3, author4, author5, author6, author7 };

            Books = new List<Book>
            {
                 new Book(Guid.NewGuid(), "The Great Gatsby", author1.Id, 1925),
                 new Book(Guid.NewGuid(), "To Kill a Mockingbird", author2.Id, 1960),
                 new Book(Guid.NewGuid(), "1984", author3.Id, 1949),
                 new Book(Guid.NewGuid(), "The Catcher in the Rye", author4.Id, 1951),
                 new Book(Guid.NewGuid(), "The Grapes of Wrath", author5.Id, 1939),
                 new Book(Guid.NewGuid(), "The Lord of the Rings", author6.Id, 1954),
                 new Book(Guid.NewGuid(), "The Hobbit", author6.Id, 1937),
                 new Book(Guid.NewGuid(), "Pride and Prejudice", author7.Id, 1813)
            };
        }
        public virtual async Task<List<Book>> GetAllBooks()
        {
            var result = await Task.FromResult(Books);
            return result;
        }
        public virtual async Task<Book?> GetBook(Guid id)
        {
            return Books.FirstOrDefault(book => book.Id == id);
        }
        public virtual async Task<bool> AddBook(Book book)
        {
            Books.Add(book);
            await Task.CompletedTask;
            return true;
        }
        public virtual async Task<bool> UpdateBook(Guid idOfBook, Book updatedBook)
        {
            Book? foundBook = Books.FirstOrDefault(book => book.Id == idOfBook);

            if (foundBook != null)
            {
                foundBook.Title = updatedBook.Title;
                foundBook.AuthorId = updatedBook.AuthorId;
                foundBook.Pages = updatedBook.Pages;
            }
            else
            {

                return false;
            }

            return true;
        }
        public virtual async Task<bool> DeleteBook(Guid id)
        {
            Book? foundBook = Books.FirstOrDefault(book => book.Id == id);
            if (foundBook != null)
            {
                Books.Remove(foundBook);
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual async Task<List<Author>> GetAllAuthors()
        {
            return Authors;
        }
        public virtual Author? GetAuthor(Guid id)
        {
            return Authors.FirstOrDefault(author => author.Id == id);
        }
        public virtual async Task<bool> AddAuthor(Author author)
        {
            Authors.Add(author);
            return true;
        }
        public virtual async Task<bool> UpdateAuthor(Guid idOfAuthor, Author updatedAuthor)
        {
            Author? foundAuthor = Authors.FirstOrDefault(author => author.Id == idOfAuthor);

            if (foundAuthor != null)
            {
                foundAuthor.Name = updatedAuthor.Name;
                foundAuthor.DateOfBirth = updatedAuthor.DateOfBirth;
                foundAuthor.PlaceOfBirth = updatedAuthor.PlaceOfBirth;
            }
            else
            {

                return false;
            }

            return true;
        }
        public virtual async Task<bool> DeleteAuthor(Guid id)
        {
            Author? foundAuthor = Authors.FirstOrDefault(author => author.Id == id);
            if (foundAuthor != null)
            {
                Authors.Remove(foundAuthor);
            }
            else
            {

                return false;
            }

            return true;
        }
    }
}
