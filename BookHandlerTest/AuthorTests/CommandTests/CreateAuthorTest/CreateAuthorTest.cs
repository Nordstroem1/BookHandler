using Application.Authors.Commands.CreateAuthor;
using BookHandlerTest.AuthorFixtures.CommandFixtures;
using Domain.Models;
using FakeItEasy;

namespace BookHandlerTest.AuthorTests.CommandTests.CreateAuthorTest
{
    public class CreateAuthorTest
    {
        [Fact]
        [Trait("Author", "CreateAuthor")]
        public async Task CreateAuthor_WhenCalled_ShouldReturnTrue()
        {
            // Arrange
            var fixture = new CreateAuthorFixture();
            var author = new Author(Guid.NewGuid(),"author1", new DateOnly(2000, 03, 27), "Sundsvall");
            A.CallTo(() => fixture._genericRepository.AddAsync(author)).Returns(author);
            var command = new CreateAuthorCommand(author);
            
            // Act
            var result = await fixture.createAuthorCommandHandler.Handle(command, CancellationToken.None);
            
            // Assert
            Assert.Equal(true, result.IsSuccess);
        }
    }
}
