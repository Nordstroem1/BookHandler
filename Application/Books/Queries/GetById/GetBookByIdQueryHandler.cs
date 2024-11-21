using Application.Dtos;
using Infrastructure.Databases;
using MediatR;
using AutoMapper;

namespace Application.Books.Queries.GetById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdCommand, BookDto>
    {
        public FakeDatabase _fakeDatabase { get; }
        public Mapper _mapper { get; }
        public GetBookByIdQueryHandler(FakeDatabase fakeDatabase, Mapper mapper)
        {
            _fakeDatabase = fakeDatabase;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.BookId.Equals(Guid.Empty))
            {
                return null;
            }
            var book = _fakeDatabase.GetBookById(request.BookId).Result;

            return _mapper.Map<BookDto>(book);
        }
    }
}
