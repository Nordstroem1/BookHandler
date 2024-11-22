using Domain.Models;
using FluentAssertions;
using FakeItEasy;
using BookHandlerTest.BookTests.BookFixtures.QueryFixtures;
using Application.Books.Queries.GetAllBooks;

namespace BookHandlerTest.BookTests.QueriesTests.GetAllbooksTest
{
    public class GetAllBookTest
    {
        [Fact]
        [Trait("Book", "GetAllBooks")]
        public void GetAllBooks_ShouldReturnListOfBooks()
        {
            //arrange
            var fixture = new GetAllBooksFixture();
            Author author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(1942, 09, 25), "place1");
            Author author2 = new Author(Guid.NewGuid(), "author2", new DateOnly(1962, 01, 2), "place2");
            Author author3 = new Author(Guid.NewGuid(), "author3", new DateOnly(1982, 12, 31), "place3");
            var books = new List<Book>
                {
                    new Book(Guid.NewGuid(),"Book 1",author1.Id,1000),
                    new Book(Guid.NewGuid(),"Book 2",author2.Id,2000),
                    new Book(Guid.NewGuid(),"Book 3",author3.Id,3000),

                };
            A.CallTo(() => fixture.FakeDatabase.GetAllBooks()).Returns(books);
            var query = new GetAllBooksQueryHandler();
            //act
            var result = fixture.GetBookByIdCommand.Handle(query, CancellationToken.None).Result;

            //assert
            result.Should().BeEquivalentTo(books).And.BeOfType<List<Book>>();

        }
    }
}
