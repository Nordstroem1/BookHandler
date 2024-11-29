using Infrastructure.Databases;
using MediatR;
using Domain.Models;
using System.Runtime.InteropServices;
using Domain.Interfaces;

namespace Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequestHandler<GetAllBooksQueryHandler, IEnumerable<Book>>
    {
        private IGenericRepository<Book> _genericRepository { get; }
        public GetAllBooksQuery(IGenericRepository<Book> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQueryHandler request, CancellationToken cancellationToken)
        {
            var bookList = await _genericRepository.GetAllAsync();
            
            return bookList;
        }
    }
}
