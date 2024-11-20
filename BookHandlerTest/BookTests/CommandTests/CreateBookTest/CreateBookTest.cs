using Application.Books.Commands.CreateBook;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using Infrastructure.Databases;
using BookHandlerTest.BookTests.BookFixtures.CommandFixtures;

namespace BookHandlerTest.BookTests.CommandTests.AddBookTest
{
    public class BookServiceTest : IClassFixture<CreateBookFixture>
    {
        private readonly FakeDatabase _fakeDatabase;
        private readonly CreateBookCommandHandler _createBookCommandHandler;
        public BookServiceTest(CreateBookFixture fixture)
        {
            _fakeDatabase = fixture.FakeDatabase;
            _createBookCommandHandler = fixture.CreateBookCommandHandler;
        }

        [Fact]
        [Trait("Book", "CreateBook")]
        public async Task AddBook_WhenCalled_ShouldReturnTrue()
        {
            // Arrange
            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);

            A.CallTo(() => _fakeDatabase.CreateBook(book)).Returns(true);

            // Act
            var command = new CreateBookCommand(book);
            var result = await _createBookCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
        }
    }
}

