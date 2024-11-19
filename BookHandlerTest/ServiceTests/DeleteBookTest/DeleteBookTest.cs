using Application.Books.Commands.DeleteBook;
using AutoFixture;
using BookHandlerTest.Fixture;
using Infrastructure.Databases;
using FakeItEasy;
using Domain.Models;
using FluentAssertions;

namespace BookHandlerTest.ServiceTests.DeleteBookTest
{
    public class DeleteBookTest : IClassFixture<DeleteBookFixture>
    {
        private readonly FakeDatabase _fakeDatabase;
        private readonly DeleteBookCommandHandler _deleteBookCommandHandler;
        public DeleteBookTest(DeleteBookFixture fixture)
        {
            _fakeDatabase = fixture.fakeDatabase;
            _deleteBookCommandHandler = fixture.deleteBookCommandHandler;
        }

        [Fact]
        [Trait("DeleteBook", "HappyCases")]
        public async Task DeleteBook_HappyCases_ShouldReturnTrue()
        {
            //arrange
            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);

            // Act
            A.CallTo(() => _fakeDatabase.DeleteBook(book.Id)).Returns(Task.FromResult(true));
            DeleteBookCommand command = new DeleteBookCommand(book.Id.ToString());
            var result = await _deleteBookCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().BeTrue();
        }
    }
}
