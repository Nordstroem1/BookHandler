using Application.Books.Commands.CreateBook;
using Application.Books.Commands.UpdateBook;
using FakeItEasy;
using Infrastructure.Databases;
namespace BookHandlerTest.Fixture
{
    public class UpdateBookFixture
    {
        public FakeDatabase FakeDatabase { get; }
        public UpdateBookCommandHandler UpdateBookCommandHandler { get; }
        public UpdateBookFixture()
        {
            var fixture = new AutoFixture.Fixture();
            FakeDatabase = A.Fake<FakeDatabase>();
            UpdateBookCommandHandler = new UpdateBookCommandHandler(FakeDatabase);
        }
    }
}