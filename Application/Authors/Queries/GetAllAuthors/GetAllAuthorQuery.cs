using Domain.Models;
using Infrastructure.Databases;
using MediatR;

namespace Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorQuery : IRequestHandler<GetAllAuthorsQueryHandler, List<Author>>
    {
        public FakeDatabase FakeDatabase { get; set; }
        public GetAllAuthorQuery(FakeDatabase fakeDatabase)
        {
            FakeDatabase = fakeDatabase;
        }
        public Task<List<Author>> Handle(GetAllAuthorsQueryHandler request, CancellationToken cancellationToken)
        {
            return FakeDatabase.GetAllAuthors();
        }
    }
}
