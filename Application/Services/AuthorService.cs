using Application.Dtos;
using AutoMapper;
using Domain.Models;
using Infrastructure.Databases;

namespace Application.Services
{
    public class AuthorService
    {
        private readonly FakeDatabase _database;
        private readonly IMapper _mapper;
        public AuthorService(FakeDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public List<Author> GetAllAuthors()
        {
            try
            {
                List<Author> authorList = _database.GetAllAuthors();
                if (authorList.Count == 0)
                {
                    throw new Exception("No authors found");
                }
                return authorList;
            }
            catch
            {
                throw new Exception("No authors found");
            }
        }
        public AuthorDto GetAuthor(Guid id)
        {
            try
            {
                Author? foundAuthor = _database.GetAuthor(id);
                if (foundAuthor == null)
                {
                    throw new Exception("Author not found");
                }

                return _mapper.Map<AuthorDto>(foundAuthor);
            }
            catch
            {
                throw new Exception("Author not found");
            }
        }
        public bool AddAuthor(Author author)
        {
            try
            {
                bool authorAdded = _database.AddAuthor(author);
                if (authorAdded)
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

                return false;
            }
        }
        public bool AddAuthorToBook(Guid bookId, Guid authorId)
        {
            try
            {
                var book = _database.GetBook(bookId);
                var author = _database.GetAuthor(authorId);

                if (book == null || author == null)
                {
                    return false;
                }

                if (book.AuthorId == author.Id)
                {
                    return true;
                }

                book.AuthorId = author.Id;
                return _database.UpdateBook(book.Id, book);
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateAuthor(Guid id, Author updatedAuthor)
        {
            try
            {
                bool authorUpdated = _database.UpdateAuthor(id, updatedAuthor);

                if (authorUpdated)
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

                return false;
            }
        }
        public bool DeleteAuthor(Guid id)
        {
            try
            {
                bool authorDeleted = _database.DeleteAuthor(id);
                if (authorDeleted)
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

                return false;
            }
        }
    }
}
