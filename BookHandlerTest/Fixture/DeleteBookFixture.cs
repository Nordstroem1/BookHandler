using Application.Books.Commands.DeleteBook;
using AutoFixture;
using FakeItEasy;
using Infrastructure.Databases;
namespace BookHandlerTest.Fixture
{
    public class DeleteBookFixture
    {
        public FakeDatabase fakeDatabase { get;}
        public DeleteBookCommandHandler deleteBookCommandHandler { get; }
        public DeleteBookFixture()
        {
            var fixture = new AutoFixture.Fixture();
            fakeDatabase = A.Fake<FakeDatabase>();
            deleteBookCommandHandler = new DeleteBookCommandHandler(fakeDatabase);
        }
    }
}
