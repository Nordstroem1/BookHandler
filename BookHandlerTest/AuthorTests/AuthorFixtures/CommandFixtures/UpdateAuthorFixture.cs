using Application.Authors.Commands.UpdateAuthor;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.AuthorTests.AuthorFixtures.CommandFixtures
{
    public class UpdateAuthorFixture
    {
        public IGenericRepository<Author> _genericRepository{ get; }
        public UpdateAuthorCommandHandler updateAuthorCommandHandler { get; }
        public UpdateAuthorFixture()
        {
            var fixture = new AutoFixture.Fixture();
            _genericRepository = A.Fake<IGenericRepository<Author>>();
            updateAuthorCommandHandler = new UpdateAuthorCommandHandler(_genericRepository);
        }
    }
}
