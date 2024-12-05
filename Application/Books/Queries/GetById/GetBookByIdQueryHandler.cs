using Application.Dtos;
using Infrastructure.Databases;
using MediatR;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Identity.Client;

namespace Application.Books.Queries.GetById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, OperationResult<BookDto>>
    {
        private IGenericRepository<BookDto> _genericRepository { get; }
        public IMapper _mapper { get; }
        public GetBookByIdQueryHandler(IGenericRepository<BookDto> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<BookDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return OperationResult<BookDto>.Fail("Failed to get book.");
            }
            var book = _genericRepository.GetByIdAsync(request.BookId).Result;
            var mappedBook = _mapper.Map<BookDto>(book);

            return OperationResult<BookDto>.Success(mappedBook);
        }
    }
}
