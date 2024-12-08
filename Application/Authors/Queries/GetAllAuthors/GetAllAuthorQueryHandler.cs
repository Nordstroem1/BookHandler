using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorsQuery, OperationResult<List<Author>>>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        private readonly IMemoryCache _memoryCache;
        private const string cacheKey = "GetAllAuthors";
        public GetAllAuthorQueryHandler(IGenericRepository<Author> genericRepository, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<List<Author>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if(!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Author>cachedAuthors))
                {

                    var allAuthorsFromDb = await _genericRepository.GetAllAsync();
                    cachedAuthors = allAuthorsFromDb;
                    _memoryCache.Set(cacheKey, cachedAuthors);

                    return OperationResult<List<Author>>.Success(cachedAuthors.ToList());
                }

                return OperationResult<List<Author>>.Success(cachedAuthors.ToList());
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error in GetAllAuthorQueryHandler: {ex.Message}");
            }
        }
    }
}
