using Application.Dtos;
using Infrastructure.Databases;
using MediatR;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Books.Queries.GetById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private IGenericRepository<BookDto> _genericRepository { get; }
        public IMapper _mapper { get; }
        public GetBookByIdQueryHandler(IGenericRepository<BookDto> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.BookId.Equals(Guid.Empty))
            {
                return null;
            }
            var book = _genericRepository.GetByIdAsync(request.BookId).Result;

            return _mapper.Map<BookDto>(book);
        }
    }
}
