using Application.Authors.Queries.GetAllAuthors;
using Application.Books.Queries.GetAllBooks;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;
using Microsoft.Extensions.Caching.Memory;

namespace BookHandlerTest.AuthorTests.AuthorFixtures.QueryFixtures
{
    public class GetAllAuthorsFixture
    {
        public IGenericRepository<Author> _genericRepository{ get; }
        public GetAllAuthorQueryHandler getAllAuthorsQueryHandler { get; }
        public IMemoryCache _memoryCache { get; }

        public GetAllAuthorsFixture()
        {
            var fixture = new AutoFixture.Fixture();
            _genericRepository = A.Fake<IGenericRepository<Author>>();
            getAllAuthorsQueryHandler = new GetAllAuthorQueryHandler(_genericRepository,_memoryCache);
        }
    }
}
