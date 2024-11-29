using Application.Books.Queries.GetAllBooks;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.BookTests.BookFixtures.QueryFixtures
{
    public class GetAllBooksFixture
    {
        public IGenericRepository<Book> genericRepository { get; }
        public GetAllBooksQuery GetBookByIdCommand { get; }
        public GetAllBooksFixture()
        {
            var fixture = new AutoFixture.Fixture();
            genericRepository = A.Fake<IGenericRepository<Book>>();
            GetBookByIdCommand = new GetAllBooksQuery(genericRepository);
        }
    }
}
