using Infrastructure.Databases;
using MediatR;
using Domain.Models;

namespace Application.Books.Queries.GetAllBooks
{
    public class GetAllBooksCommandHandler : IRequestHandler<GetAllBooksCommand, List<Book>>
    {
        public FakeDatabase _fakeDatabase { get; }
        public GetAllBooksCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public async Task<List<Book>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {
            var bookList = await Task.Run(() => _fakeDatabase.GetAllBooks());

            return bookList;
        }
    }
}
