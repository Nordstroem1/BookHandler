using MediatR;
using Domain.Models;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, OperationResult<List<Book>>>
    {
        private IGenericRepository<Book> _genericRepository { get; }
        private IMemoryCache _memoryCache { get; }
        private const string cacheKey = "GetAllBooks";


        public GetAllBooksQueryHandler(IGenericRepository<Book> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<OperationResult<List<Book>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Book> cachedBooks))
                {
                    if (cachedBooks == null || !cachedBooks.Any())
                    {
                        return OperationResult<List<Book>>.Fail("No books found");
                    }

                    var allBooks = await _genericRepository.GetAllAsync();
                    _memoryCache.Set(cacheKey, allBooks);

                    return OperationResult<List<Book>>.Success(cachedBooks.ToList());
                }

                return OperationResult<List<Book>>.Success(cachedBooks.ToList());
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error while trying to get all authors: {ex.Message}");
            }
        }
    }
}
