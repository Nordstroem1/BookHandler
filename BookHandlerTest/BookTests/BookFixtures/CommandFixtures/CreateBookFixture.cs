using Application.Books.Commands.CreateBook;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
namespace BookHandlerTest.BookTests.BookFixtures.CommandFixtures
{
    public class CreateBookFixture
    {
        public IGenericRepository<Book> genericRepository { get; }
        public CreateBookCommandHandler CreateBookCommandHandler { get; }
        public CreateBookFixture()
        {
            var fixture = new AutoFixture.Fixture();
            genericRepository = A.Fake<IGenericRepository<Book>>();
            CreateBookCommandHandler = new CreateBookCommandHandler(genericRepository);
        }
    }
}
