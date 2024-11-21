using Application.Authors.Commands.DeleteAuthor;
using AutoFixture;
using BookHandlerTest.AuthorTests.AuthorFixtures.CommandFixtures;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;

namespace BookHandlerTest.AuthorTests.CommandTests.DeleteAuthorTest
{
    public class DeleteAuthorTest
    {
        [Fact]
        [Trait("Author", "DeleteAuthor")]
        public async Task DeleteAuthor_ShouldReturnSucces()
        {
            // Arrange
            var deleteAuthorFixture = new DeleteAuthorFixture();
            var author = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            A.CallTo(() => deleteAuthorFixture.fakeDatabase.DeleteAuthor(author.Id)).Returns(true);
            var deleteAuthorCommand = new DeleteAuthorCommand(author.Id);

            // Act
            var result = await deleteAuthorFixture.deleteAuthorCommandHandler.Handle(deleteAuthorCommand, CancellationToken.None);
            
            // Assert
            result.Should().BeTrue();
        }
    }
}
