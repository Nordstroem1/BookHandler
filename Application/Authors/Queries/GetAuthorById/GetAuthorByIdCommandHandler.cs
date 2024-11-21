using Application.Dtos;
using AutoMapper;
using Infrastructure.Databases;
using MediatR;
namespace Application.Authors.Queries.GetAuthorById
{
    public class GetAuthorByIdCommandHandler : IRequestHandler<GetAuthorByIdCommand, AuthorDto>
    {
        public IMapper _mapper { get; }
        public FakeDatabase _fakeDatabase { get; }
        public GetAuthorByIdCommandHandler(FakeDatabase fakeDatabase, IMapper mapper)
        {
            _fakeDatabase = fakeDatabase;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.AuthorId.Equals(Guid.Empty))
            {
                return null;
            }
            var author = _fakeDatabase.GetAuthorById(request.AuthorId).Result;

            return _mapper.Map<AuthorDto>(author);
        }
    }
}
