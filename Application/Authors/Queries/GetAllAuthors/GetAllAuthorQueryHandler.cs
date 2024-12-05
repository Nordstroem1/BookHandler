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
        public GetAllAuthorQueryHandler(IGenericRepository<Author> genericRepository, IMemoryCache _memoryCache)
        {
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<List<Author>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if(!_memoryCache.TryGetValue(cacheKey, out IEnumerable<Author>cachedAuthors))
                {
                    if (cachedAuthors == null || !cachedAuthors.Any())
                    {
                        return OperationResult<List<Author>>.Fail("No Authors found.");
                    }

                    var allAuthorsFromDb = await _genericRepository.GetAllAsync();
                    _memoryCache.Set(cacheKey, cachedAuthors);

                    return OperationResult<List<Author>>.Success(cachedAuthors.ToList());
                }

                return OperationResult<List<Author>>.Success(cachedAuthors.ToList());
            }
            catch
            {
                throw new ApplicationException("Something went wrong while getting the allAuthorsFromDb.");
            }
        }
    }
}
