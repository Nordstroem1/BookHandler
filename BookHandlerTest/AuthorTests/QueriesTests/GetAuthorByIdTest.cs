using Application.Authors.Queries.GetAuthorById;
using Application.Dtos;
using BookHandlerTest.AuthorTests.AuthorFixtures.QueryFixtures;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;

namespace BookHandlerTest.AuthorTests.QueriesTests
{
    public class GetAuthorByIdTest
    {
        [Fact]
        [Trait("Author", "GetAuthorById")]
        public async void GetAuthorById_Success()
        {
            // Arrange
            var fixture = new GetAuthorByIdFixture();
            var author = new Author(Guid.NewGuid(), "author1", new DateOnly(1942, 09, 25), "place1");
            var authorDto = new AuthorDto(author.Id, "author1");
            A.CallTo(() => fixture.fakeDatabase.GetAuthorById(author.Id)).Returns(author);
            var query = new GetAuthorByIdQuery(author.Id);
            
            // Act
            var result = await fixture.getAuthorByIdQueryHandler.Handle(query, CancellationToken.None);

            //assert
            result.Should().BeEquivalentTo(authorDto).And.BeOfType<AuthorDto>();
        }
    }
}
