using Application.Authors.Queries.GetAllAuthors;
using Application.Authors.Queries.GetAuthorById;
using Application.Dtos;
using Application.MappingProfiles;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using FakeItEasy;
using Infrastructure.Databases;

namespace BookHandlerTest.AuthorTests.AuthorFixtures.QueryFixtures
{
    public class GetAuthorByIdFixture
    {
        public IGenericRepository<Author> _genericRepository{ get; }
        public GetAuthorByIdQueryHandler getAuthorByIdQueryHandler { get; }
        public IMapper mapper { get; }
        public GetAuthorByIdFixture()
        {
            var fixture = new AutoFixture.Fixture();
            _genericRepository = A.Fake<IGenericRepository<Author>>();
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AuthormappingProfile())));
            getAuthorByIdQueryHandler = new GetAuthorByIdQueryHandler(_genericRepository, mapper);
        }
    }
}
