using Application.Books.Commands.CreateBook;
using Domain.Models;
using FakeItEasy;
using BookHandlerTest.BookTests.BookFixtures.CommandFixtures;

namespace BookHandlerTest.BookTests.CommandTests.AddBookTest
{
    public class BookServiceTest : IClassFixture<CreateBookFixture>
    {
        [Fact]
        [Trait("Book", "CreateBook")]
        public async Task AddBook_WhenCalled_ShouldReturnTrue()
        {
            // Arrange
            var fixture = new CreateBookFixture();
            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);

            A.CallTo(() => fixture.genericRepository.AddAsync(book)).Returns(book);

            // Act
            var command = new CreateBookCommand(book);
            var result = await fixture.CreateBookCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            result.Equals(book);
        }
    }
}

