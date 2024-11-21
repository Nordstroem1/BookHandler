using FluentAssertions;
using FakeItEasy;
using Domain.Models;
using BookHandlerTest.AuthorTests.AuthorFixtures.CommandFixtures;
using Application.Authors.Commands.UpdateAuthor;

namespace BookHandlerTest.AuthorTests.CommandTests.UpdateAuthorTest
{
    public class UpdateAuthorTest
    {
        [Fact]
        [Trait("Author", "UpdateAuthor")]
        public async Task UpdateAuthor_ShouldReturnTrueAsync()
        {
            // Arrange
            var fixture = new UpdateAuthorFixture();
            var author = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            A.CallTo(() => fixture.fakeDatabase.UpdateAuthor(author)).Returns(true);
            var command = new UpdateAuthorCommand(author);
            // Act
            var result = await fixture.updateAuthorCommandHandler.Handle(command, CancellationToken.None);
            // Assert
            result.Should().BeTrue();
        }
    }
}
