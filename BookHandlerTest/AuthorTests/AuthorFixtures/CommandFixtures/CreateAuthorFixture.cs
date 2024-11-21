using Application.Authors.Commands.CreateAuthor;
using Application.Books.Commands.CreateBook;
using AutoFixture;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.Fixtures.Author.CommandFixtures
{
    public class CreateAuthorFixture
    {
        public FakeDatabase fakeDatabase { get; }
        public CreateAuthorCommandHandler createAuthorCommandHandler { get; }
        public CreateAuthorFixture()
        {
            var fixture = new AutoFixture.Fixture();
            fakeDatabase = A.Fake<FakeDatabase>();
            createAuthorCommandHandler = new CreateAuthorCommandHandler(fakeDatabase);
        }
    }
}
