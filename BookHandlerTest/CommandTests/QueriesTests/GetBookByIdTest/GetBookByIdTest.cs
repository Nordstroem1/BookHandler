using Application.Books.Queries.Books.GetById;
using BookHandlerTest.Fixtures;
using FakeItEasy;
using FluentAssertions;
using Domain.Models;
using Application.Dtos;

namespace BookHandlerTest.CommandTests.QueriesTests.GetBookByIdTest
{
    public class GetBookByIdTest
    {
        [Fact]
        [Trait("QueryTests", "GetBookById")]
        public async Task GetBookById_ShouldReturnABook()
        {
            // Arrange
            var fixture = new GetBookByIdFixture();
            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);
            var bookDto = new BookDto(book.Id, book.Title);
            A.CallTo(() => fixture.FakeDatabase.GetBook(book.Id)).Returns(book);
            var query = new GetBookByIdCommand(book.Id);

            // Act
            var result = await fixture.GetBookByIdCommand.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeOfType<BookDto>().And.BeEquivalentTo(bookDto);
        }
    }
}
