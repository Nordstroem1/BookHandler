using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsCommandHandler : IRequestHandler<GetAllAuthorsCommand, List<Author>>
    {
        public FakeDatabase FakeDatabase { get; set; }
        public GetAllAuthorsCommandHandler(FakeDatabase fakeDatabase)
        {
            FakeDatabase = fakeDatabase;
        }
        public Task<List<Author>> Handle(GetAllAuthorsCommand request, CancellationToken cancellationToken)
        {
            return FakeDatabase.GetAllAuthors();
        }
    }
}
