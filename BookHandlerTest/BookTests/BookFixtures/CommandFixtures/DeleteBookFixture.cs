using Application.Books.Commands.DeleteBook;
using AutoFixture;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;
namespace BookHandlerTest.BookTests.BookFixtures.CommandFixtures
{
    public class DeleteBookFixture
    {
        public IGenericRepository<Book> genericRepository { get; }
        public DeleteBookCommandHandler deleteBookCommandHandler { get; }
        public DeleteBookFixture()
        {
            var fixture = new Fixture();
            genericRepository = A.Fake<IGenericRepository<Book>>();
            deleteBookCommandHandler = new DeleteBookCommandHandler(genericRepository);
        }
    }
}
