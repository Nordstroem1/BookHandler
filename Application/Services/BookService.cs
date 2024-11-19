using Application.Dtos;
using Domain.Models;
using Infrastructure.Databases;
using AutoMapper;
using System.Text.RegularExpressions;
using MediatR;

namespace Application.Services
{
    public class BookService 
    {
        private readonly FakeDatabase _database;
        private readonly IMapper _mapper;
        public BookService(FakeDatabase database, IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _database = database;
        }
        public virtual async Task<List<Book>> GetAllBooks()
        {
            try
            {
                List<Book> booklist =  await _database.GetAllBooks();

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
        public virtual async Task<BookDto> GetBook(Guid id)
        {
            try
            {
                Book? foundBook = await _database.GetBook(id);

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

    }
}