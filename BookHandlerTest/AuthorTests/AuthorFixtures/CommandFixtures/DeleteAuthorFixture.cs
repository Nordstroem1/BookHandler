using Application.Authors.Commands.DeleteAuthor;
using AutoFixture;
using Infrastructure.Databases;
using FakeItEasy;
namespace BookHandlerTest.AuthorTests.AuthorFixtures.CommandFixtures
{
    public class DeleteAuthorFixture
    {
        public FakeDatabase fakeDatabase { get; }
        public DeleteAuthorCommandHandler deleteAuthorCommandHandler { get; }
        public DeleteAuthorFixture()
        {
            var fixture = new AutoFixture.Fixture();
            fakeDatabase = A.Fake<FakeDatabase>();
            deleteAuthorCommandHandler = new DeleteAuthorCommandHandler(fakeDatabase);
        }
    }
}
