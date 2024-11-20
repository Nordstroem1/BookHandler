using Application.Books.Commands.DeleteBook;
using AutoFixture;
using FakeItEasy;
using Infrastructure.Databases;
namespace BookHandlerTest.BookTests.BookFixtures.CommandFixtures
{
    public class DeleteBookFixture
    {
        public FakeDatabase fakeDatabase { get; }
        public DeleteBookCommandHandler deleteBookCommandHandler { get; }
        public DeleteBookFixture()
        {
            var fixture = new Fixture();
            fakeDatabase = A.Fake<FakeDatabase>();
            deleteBookCommandHandler = new DeleteBookCommandHandler(fakeDatabase);
        }
    }
}
