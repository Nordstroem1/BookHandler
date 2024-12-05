using FakeItEasy;
using FluentAssertions;
using Domain.Models;
using Application.Dtos;
using BookHandlerTest.BookTests.BookFixtures.QueryFixtures;
using Application.Books.Queries.GetById;

namespace BookHandlerTest.BookTests.QueriesTests.GetBookByIdTest
{
    public class GetBookByIdTest
    {
        [Fact]
        [Trait("Book", "GetBookById")]
        public async Task GetBookById_ShouldReturnABook()
        {
            // Arrange
            var fixture = new GetBookByIdFixture();
            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);
            var bookDto = new BookDto(book.Id, book.Title);
            A.CallTo(() => fixture.genericRepository.GetByIdAsync(book.Id)).Returns(bookDto);
            var query = new GetBookByIdQuery(book.Id);

            // Act
            var result = await fixture.GetBookByIdCommand.Handle(query, CancellationToken.None);

            // Assert
            result.Data.Should().BeOfType<BookDto>().And.BeEquivalentTo(bookDto);
        }
    }
}
