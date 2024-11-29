using Application.Authors.Commands.CreateAuthor;
using Application.Dtos;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.AuthorFixtures.CommandFixtures
{
    public class CreateAuthorFixture
    {
        public IGenericRepository<Author> _genericRepository { get; }
        public IMapper mapper { get; }
        public CreateAuthorCommandHandler createAuthorCommandHandler { get; }
        public CreateAuthorFixture()
        {
            var fixture = new AutoFixture.Fixture();
            _genericRepository = A.Fake<IGenericRepository<Author>>();
            mapper = A.Fake<IMapper>();
            createAuthorCommandHandler = new CreateAuthorCommandHandler(_genericRepository);
        }
    }
}
