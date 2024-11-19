using Application.Books.Commands.CreateBook;
using FakeItEasy;
using Infrastructure.Databases;
namespace BookHandlerTest.Fixture
{
    public class CreateBookFixture
    {
        public FakeDatabase FakeDatabase { get; }
        public CreateBookCommandHandler CreateBookCommandHandler { get; }
        public CreateBookFixture()
        {
            var fixture = new AutoFixture.Fixture();
            FakeDatabase = A.Fake<FakeDatabase>();
            CreateBookCommandHandler = new CreateBookCommandHandler(FakeDatabase);
        }
    }
}
