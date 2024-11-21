using Application.Authors.Commands.CreateAuthor;
using AutoMapper;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.Fixtures.Author.CommandFixtures
{
    public class CreateAuthorFixture
    {
        public FakeDatabase fakeDatabase { get; }
        public IMapper mapper { get; }
        public CreateAuthorCommandHandler createAuthorCommandHandler { get; }
        public CreateAuthorFixture()
        {
            var fixture = new AutoFixture.Fixture();
            fakeDatabase = A.Fake<FakeDatabase>();
            mapper = A.Fake<IMapper>();
            createAuthorCommandHandler = new CreateAuthorCommandHandler(fakeDatabase);
        }
    }
}
