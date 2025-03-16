using Application.Books.Queries.GetAllBooks;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;
using Microsoft.Extensions.Caching.Memory;

namespace BookHandlerTest.BookTests.BookFixtures.QueryFixtures
{
    public class GetAllBooksFixture
    {
        public IGenericRepository<Book> genericRepository { get; }
        public GetAllBooksQueryHandler GetBookByIdCommand { get; }
        public IMemoryCache memoryCache { get; }
        public GetAllBooksFixture()
        {
            var fixture = new AutoFixture.Fixture();
            memoryCache = A.Fake<IMemoryCache>();
            genericRepository = A.Fake<IGenericRepository<Book>>();
            GetBookByIdCommand = new GetAllBooksQueryHandler(genericRepository, memoryCache);
        }
    }
}
