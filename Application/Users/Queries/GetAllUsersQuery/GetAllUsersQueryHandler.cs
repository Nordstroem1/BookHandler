using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Users.Queries.GetAllUsersQuery
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, OperationResult<List<User>>>
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IMemoryCache _memoryCache;
        public GetAllUsersQueryHandler(IGenericRepository<User> genericRepository, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _genericRepository = genericRepository;
        }
        public async Task<OperationResult<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            if(!_memoryCache.TryGetValue("GetAllUsers", out IEnumerable<User> cachedUsers))
            {
                if (cachedUsers == null || !cachedUsers.Any())
                {
                    return OperationResult<List<User>>.Fail("No users found");
                }

                var allUsers = await _genericRepository.GetAllAsync();
                _memoryCache.Set("GetAllUsers", allUsers);

                return OperationResult<List<User>>.Success(cachedUsers.ToList());
            }
            return OperationResult<List<User>>.Success(cachedUsers.ToList());
        }
    }
}
