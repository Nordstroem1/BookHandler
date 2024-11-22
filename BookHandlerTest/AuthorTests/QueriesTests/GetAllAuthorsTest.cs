using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using BookHandlerTest.AuthorTests.AuthorFixtures.QueryFixtures;
using Application.Authors.Queries.GetAllAuthors;
namespace BookHandlerTest.AuthorTests.QueriesTests
{
    public class GetAllAuthorsTest
    {
        [Fact]
        [Trait("Authors", "GetAllAuthors")]
        public async void GetAllAuthorsTest_ShouldReturnListOfAuthors()
        {
            // Arrange
            var fixture = new GetAllAuthorsFixture();
            var query = new GetAllAuthorsQueryHandler();
            var authorList = new List<Author>
            {
                new Author(Guid.NewGuid(), "author1", new DateOnly(1942, 09, 25), "place1"),
                new Author(Guid.NewGuid(), "author2", new DateOnly(1962, 01, 2), "place2"),
                new Author(Guid.NewGuid(), "author3", new DateOnly(1982, 12, 31), "place3")
            };
            A.CallTo(() => fixture.fakeDatabase.GetAllAuthors()).Returns(authorList);
            // Act
            var result = await fixture.getAllAuthorsQueryHandler.Handle(query, CancellationToken.None);
            // Assert
            result.Should().BeOfType<List<Author>>();
        }

    }
}
