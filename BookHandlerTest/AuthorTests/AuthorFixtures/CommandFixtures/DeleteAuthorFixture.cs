using Application.Authors.Commands.DeleteAuthor;
using Infrastructure.Databases;
using FakeItEasy;
using Domain.Interfaces;
using Domain.Models;
namespace BookHandlerTest.AuthorTests.AuthorFixtures.CommandFixtures
{
    public class DeleteAuthorFixture
    {
        public IGenericRepository<Author> _genericRepository { get; }
        public DeleteAuthorCommandHandler deleteAuthorCommandHandler { get; }
        public DeleteAuthorFixture()
        {
            var fixture = new AutoFixture.Fixture();
            _genericRepository = A.Fake<IGenericRepository<Author>>();
            deleteAuthorCommandHandler = new DeleteAuthorCommandHandler(_genericRepository);
        }
    }
}
