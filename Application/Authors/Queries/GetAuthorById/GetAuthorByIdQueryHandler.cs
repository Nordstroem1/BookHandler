using Application.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, OperationResult<AuthorDto>>
    {
        private IMapper _mapper { get; }
        private IGenericRepository<AuthorDto> _genericRepository { get; }
        public GetAuthorByIdQueryHandler(IGenericRepository<AuthorDto> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<AuthorDto>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.AuthorId.Equals(Guid.Empty))
            {
                return null;
            }
            var author = await _genericRepository.GetByIdAsync(request.AuthorId);
            var authorDto = _mapper.Map<AuthorDto>(author);
            
            return OperationResult<AuthorDto>.Success(authorDto);
        }
    }
}
