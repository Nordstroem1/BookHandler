using Application.Authors.Commands.CreateAuthor;
using Application.Dtos;
using AutoMapper;
using Castle.Core.Logging;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace BookHandlerTest.AuthorFixtures.CommandFixtures
{
    public class CreateAuthorFixture
    {
        public IGenericRepository<Author> _genericRepository { get; }
        public IMapper mapper { get; }
        public CreateAuthorCommandHandler createAuthorCommandHandler { get; }
        public ILogger<CreateAuthorCommandHandler> _logger { get; }
        public IMemoryCache _memoryCache { get; }

        public CreateAuthorFixture()
        {
            var fixture = new AutoFixture.Fixture();
            _genericRepository = A.Fake<IGenericRepository<Author>>();
            mapper = A.Fake<IMapper>();
            _memoryCache = A.Fake<IMemoryCache>();
            createAuthorCommandHandler = new CreateAuthorCommandHandler(_genericRepository, _logger);
        }
    }
}
