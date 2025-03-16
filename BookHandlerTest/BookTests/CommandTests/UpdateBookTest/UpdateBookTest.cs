using Application.Books.Commands.UpdateBook;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using BookHandlerTest.BookTests.BookFixtures.CommandFixtures;

namespace BookHandlerTest.BookTests.CommandTests.UpdateBookTest
{
    public class UpdateBookTest : IClassFixture<UpdateBookFixture>
    {
        [Fact]
        [Trait("Book", "UpdateBook")]
        public async Task UpdateBook_WhenCalled_ShouldReturnTrue()
        {
            //arrange
            var fixture = new UpdateBookFixture();
            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);
            var updatedBook = new Book(book.Id, "updatedBook", author1.Id, 1950);
            A.CallTo(() => fixture.genericRepository.UpdateAsync(updatedBook)).Returns(updatedBook);

            //act
            var result = await fixture.UpdateBookCommandHandler.Handle(new UpdateBookCommand(updatedBook), CancellationToken.None);

            //assert
            result.Equals(true);
        }
    }
}
