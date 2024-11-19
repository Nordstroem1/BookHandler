using Application.Books.Commands.CreateBook;
using Application.Books.Commands.DeleteBook;
using Application.Books.Commands.UpdateBook;
using Application.Dtos;
using AutoMapper;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using Infrastructure.Databases;
using MediatR;
using Xunit.Abstractions;
using AutoFixture;
using BookHandlerTest.Fixture;

namespace BookHandlerTest.ServiceTests
{
    public class BookServiceTest : IClassFixture<BookServiceFixture>
    {
        private readonly FakeDatabase _fakeDatabase;
        private readonly IMapper _mapper;
        private readonly CreateBookCommandHandler _createBookCommandHandler;
        public BookServiceTest(ITestOutputHelper outputter, CreateBookCommandHandler createBookCommandHandler)
        {
            var fixture = new Fixture(); // This line is now correct
            _fakeDatabase = A.Fake<FakeDatabase>();
            _createBookCommandHandler = new CreateBookCommandHandler(_fakeDatabase);
        }

        // Other code remains unchanged
    }
}

//        [Fact]
//        [Trait("Commands", "HappyCases")]
//        public async Task UpdateBook_WhenCalled_ShouldReturnTrue()
//        {
//            //arrange
//            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
//            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);
//            var updatedBook = new Book(book.Id, "updatedBook", author1.Id, 1950);
//            A.CallTo(() => _fakeDatabase.UpdateBook(book.Id, updatedBook)).Returns(true);
//            //act
//            var result = await _createBookCommandHandler.Send(new UpdateBookCommand(updatedBook));
//            //assert
//            result.Should().BeTrue();
//        }

//        [Fact]
//        [Trait("Commands", "HappyCases")]
//        public async Task DeleteBook_WhenCalled_ShouldReturnTrue()
//        {
//            //arrange
//            var author1 = new Author(Guid.NewGuid(), "author1", new DateOnly(2000, 03, 27), "Sundsvall");
//            var book = new Book(Guid.NewGuid(), "Book1", author1.Id, 2000);
//            A.CallTo(() => _fakeDatabase.DeleteBook(book.Id)).Returns(true);
//            //act
//            var result = await _mediator.Send(new DeleteBookCommand(book.Id.ToString()));
//            //assert
//            result.Should().BeTrue();
//        }
//    }
//}
