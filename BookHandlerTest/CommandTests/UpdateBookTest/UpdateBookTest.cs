using Application.Books.Commands.UpdateBook;
using AutoMapper;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using Infrastructure.Databases;
using BookHandlerTest.Fixture;

namespace BookHandlerTest.ServiceTests.UpdateBookTest
{
    public class UpdateBookTest : IClassFixture<UpdateBookFixture>
    {
        private readonly FakeDatabase _fakeDatabase;
        private readonly IMapper _mapper;
        private readonly UpdateBookCommandHandler _updateBookCommandHandler;
        public UpdateBookTest(UpdateBookFixture fixture)
        {
            _fakeDatabase = fixture.FakeDatabase;
            _updateBookCommandHandler = fixture.UpdateBookCommandHandler;
        }
        [Fact]
        [Trait("UpdateBook", "HappyCases")]
        public async Task UpdateBook_WhenCalled_ShouldReturnTrue()
        {
            //arrange
            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);
            var updatedBook = new Book(book.Id, "updatedBook", author1.Id, 1950);
            A.CallTo(() => _fakeDatabase.UpdateBook(book.Id, updatedBook)).Returns(true);
            //act
            var result = await _updateBookCommandHandler.Handle(new UpdateBookCommand(updatedBook), CancellationToken.None);
            //assert
            result.Should().BeTrue();
        }
    }
}
