

using Application.Authors.Commands.CreateAuthor;
using Application.Authors.Commands.UpdateAuthor;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.AuthorTests.AuthorFixtures.CommandFixtures
{
    public class UpdateAuthorFixture
    {
        public FakeDatabase fakeDatabase { get; }
        public UpdateAuthorCommandHandler updateAuthorCommandHandler { get; }
        public UpdateAuthorFixture()
        {
            var fixture = new AutoFixture.Fixture();
            fakeDatabase = A.Fake<FakeDatabase>();
            updateAuthorCommandHandler = new UpdateAuthorCommandHandler(fakeDatabase);
        }
    }
}
