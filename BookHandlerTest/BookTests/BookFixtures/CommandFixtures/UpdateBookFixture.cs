using Application.Books.Commands.CreateBook;
using Application.Books.Commands.UpdateBook;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;
namespace BookHandlerTest.BookTests.BookFixtures.CommandFixtures
{
    public class UpdateBookFixture
    {
        public IGenericRepository<Book> genericRepository { get; }
        public UpdateBookCommandHandler UpdateBookCommandHandler { get; }
        public UpdateBookFixture()
        {
            var fixture = new AutoFixture.Fixture();
            genericRepository = A.Fake<IGenericRepository<Book>>();
            UpdateBookCommandHandler = new UpdateBookCommandHandler(genericRepository);
        }
    }
}