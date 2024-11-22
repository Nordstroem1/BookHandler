using Application.Authors.Queries.GetAllAuthors;
using Application.Books.Queries.GetAllBooks;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.AuthorTests.AuthorFixtures.QueryFixtures
{
    public class GetAllAuthorsFixture
    {
        public FakeDatabase fakeDatabase { get; }
        public GetAllAuthorQuery getAllAuthorsQueryHandler { get; }
        public GetAllAuthorsFixture()
        {
            var fixture = new AutoFixture.Fixture();
            fakeDatabase = A.Fake<FakeDatabase>();
            getAllAuthorsQueryHandler = new GetAllAuthorQuery(fakeDatabase);
        }
    }
}
