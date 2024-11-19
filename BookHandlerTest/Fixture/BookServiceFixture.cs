using Application.Books.Commands.CreateBook;
using FakeItEasy;
using Infrastructure.Databases;
using AutoFixture;

namespace BookHandlerTest.Fixture
{
    public class BookServiceFixture
    {
        public FakeDatabase FakeDatabase { get; }
        public CreateBookCommandHandler CreateBookCommandHandler { get; }

        public BookServiceFixture()
        {
            var fixture = new Fixture();
            FakeDatabase = A.Fake<FakeDatabase>();
            CreateBookCommandHandler = new CreateBookCommandHandler(FakeDatabase);
        }
    }
}
