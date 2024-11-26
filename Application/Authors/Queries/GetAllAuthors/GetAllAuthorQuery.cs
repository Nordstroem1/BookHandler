using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorQuery : IRequestHandler<GetAllAuthorsQueryHandler, IEnumerable<Author>>
    {
        private readonly IGenericRepository<Author> _genericRepository;
        public GetAllAuthorQuery(IGenericRepository<Author> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQueryHandler request, CancellationToken cancellationToken)
        {
            try
            {
                var authors = await _genericRepository.GetAllAsync();
                return authors;
            }
            catch
            {
                throw new Exception("Something went wrong while getting the authors.");
            }
        }
    }
}
