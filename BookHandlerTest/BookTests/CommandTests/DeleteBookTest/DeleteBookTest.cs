using Application.Books.Commands.DeleteBook;
using FakeItEasy;
using Domain.Models;
using FluentAssertions;
using BookHandlerTest.BookTests.BookFixtures.CommandFixtures;

namespace BookHandlerTest.BookTests.CommandTests.DeleteBookTest
{
    public class DeleteBookTest
    {
        [Fact]
        [Trait("Book", "DeleteBook")]
        public async Task DeleteBook_HappyCases_ShouldReturnTrue()
        {
            //arrange
            var fixture = new DeleteBookFixture();
            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);
            DeleteBookCommand command = new DeleteBookCommand(book.Id.ToString());
            
            A.CallTo(() => fixture.genericRepository.GetByIdAsync(book.Id)).Returns(book);
            A.CallTo(() => fixture.genericRepository.DeleteAsync(book)).Returns(Task.FromResult(book));

            // Act
            var result = fixture.deleteBookCommandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsCompletedSuccessfully);
        }
    }
}
