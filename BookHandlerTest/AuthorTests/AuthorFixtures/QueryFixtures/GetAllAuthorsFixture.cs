using Application.Authors.Queries.GetAllAuthors;
using Application.Books.Queries.GetAllBooks;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.AuthorTests.AuthorFixtures.QueryFixtures
{
    public class GetAllAuthorsFixture
    {
        public IGenericRepository<Author> _genericRepository{ get; }
        public GetAllAuthorQuery getAllAuthorsQueryHandler { get; }
        public GetAllAuthorsFixture()
        {
            var fixture = new AutoFixture.Fixture();
            _genericRepository = A.Fake<IGenericRepository<Author>>();
            getAllAuthorsQueryHandler = new GetAllAuthorQuery(_genericRepository);
        }
    }
}
