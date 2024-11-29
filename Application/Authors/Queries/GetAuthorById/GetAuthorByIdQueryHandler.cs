using Application.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Databases;
using Infrastructure.Repositories;
using MediatR;
namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
    {
        private IMapper _mapper { get; }
        private IGenericRepository<Author> _genericRepository { get; }
        public GetAuthorByIdQueryHandler(IGenericRepository<Author> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.AuthorId.Equals(Guid.Empty))
            {
                return null;
            }
            var author = await _genericRepository.GetByIdAsync(request.AuthorId);

            return _mapper.Map<AuthorDto>(author);
        }
    }
}
